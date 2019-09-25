using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Windows.Graphics.Capture;
using Windows.Graphics.DirectX;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;

using QuickCapture.Interop;
using QuickCapture.Services.Interfaces;

namespace QuickCapture.Models
{
    internal class TrackingProcess : IDisposable
    {
        private readonly IConfigurationService _configuration;
        private readonly IDirectXService _directX;
        private readonly IReadingHistoryService _history;
        private readonly IntPtr _hWnd;
        private readonly Process _process;
        private readonly IBarcodeReaderService _reader;
        private Direct3D11CaptureFramePool _captureFramePool;
        private GraphicsCaptureItem _captureItem;
        private GraphicsCaptureSession _captureSession;
        private IDisposable _disposable;
        private int _frames;

        public IntPtr WindowHandle => _process.MainWindowHandle;

        public TrackingProcess(Process process, IConfigurationService configuration, IDirectXService directX, IBarcodeReaderService reader, IReadingHistoryService history)
        {
            _process = process;
            _hWnd = process.MainWindowHandle;
            _configuration = configuration;
            _directX = directX;
            _reader = reader;
            _history = history;
        }

        public void Dispose()
        {
            _captureSession?.Dispose();
            _captureFramePool?.Dispose();
            _disposable?.Dispose();
            _process?.Dispose();
        }

        public void Start()
        {
            do
            {
                _captureItem = CaptureHelper.CreateItemForWindow(_hWnd);
                if (_captureItem == null)
                    Task.Delay(1000).Wait();
            } while (_captureItem == null);
            _captureItem.Closed += (_, __) => Dispose();

            var device = Direct3D11Helper.CreateDeviceFromSharpDXDevice(_directX.Device);
            _captureFramePool = Direct3D11CaptureFramePool.Create(device, DirectXPixelFormat.B8G8R8A8UIntNormalized, 2, _captureItem.Size);
            _captureSession = _captureFramePool.CreateCaptureSession(_captureItem);
            _captureSession.StartCapture();

            _configuration.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName != nameof(_configuration.CaptureFrames) && e.PropertyName != nameof(_configuration.CaptureRate))
                    return;
                if (_configuration.CaptureFrames > 0 && _configuration.CaptureRate >= 250)
                    SubscribeChanges();
            };
            SubscribeChanges();
        }

        private void SubscribeChanges()
        {
            _disposable?.Dispose();
            _disposable = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromMilliseconds(_configuration.CaptureRate)).Subscribe(async _ =>
            {
                // try to detect 2D barcode
                using var frame = _captureFramePool.TryGetNextFrame();
                if (frame == null)
                    return;

                using var softwareBitmap = await SoftwareBitmap.CreateCopyFromSurfaceAsync(frame.Surface);
                using var stream = new InMemoryRandomAccessStream();
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                encoder.SetSoftwareBitmap(softwareBitmap);
                await encoder.FlushAsync();

                using var bitmap = new Bitmap(stream.AsStream());

                var texts = _reader.Read(bitmap);
                if (texts.Count > 0)
                    _frames++;
                else
                    _frames = 0;

                if (_frames >= _configuration.CaptureFrames)
                    foreach (var text in texts.Where(text => _history.History.SingleOrDefault(w => w.Text == text) == null))
                    {
                        if (!Directory.Exists(Constants.SituationsDirPath))
                            Directory.CreateDirectory(Constants.SituationsDirPath);

                        var path = Path.Combine(Constants.SituationsDirPath, $"{Path.GetFileName(_process.MainModule?.FileName) ?? "Unknown"}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
                        bitmap.Save(path, ImageFormat.Png);
                        _history.Append(new ReadingResult { RecordAt = DateTime.Now, Situation = path.Replace($@"{Constants.SituationsDirPath}\\", "~/"), Text = text });
                    }
                else
                    Debug.WriteLine("not detected 2D barcode in screen");
            });
        }
    }
}