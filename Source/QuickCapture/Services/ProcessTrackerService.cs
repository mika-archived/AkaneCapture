using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;

using QuickCapture.Models;
using QuickCapture.Services.Interfaces;

namespace QuickCapture.Services
{
    internal class ProcessTrackerService : IProcessTrackerService, IDisposable
    {
        private readonly IConfigurationService _configuration;
        private readonly IDirectXService _directX;
        private readonly IReadingHistoryService _history;
        private readonly IToastNotificationService _notificator;
        private readonly IBarcodeReaderService _reader;
        private IDisposable _disposable;

        // oh...
        public ProcessTrackerService(IConfigurationService configuration, IDirectXService directX, IBarcodeReaderService reader, IReadingHistoryService history, IToastNotificationService notificator)
        {
            _configuration = configuration;
            _directX = directX;
            _reader = reader;
            _history = history;
            _notificator = notificator;
            Tracks = new ObservableCollection<TrackingProcess>();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        public ObservableCollection<TrackingProcess> Tracks { get; }

        public void StartTrack()
        {
            _disposable = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(10)).Subscribe(_ => TrackingLoop());
        }

        public void StopTrack()
        {
            _disposable.Dispose();
            Tracks.Clear();
        }

        private void TrackingLoop()
        {
            foreach (var process in Process.GetProcesses())
            {
                if (!_configuration.TargetProcesses.Contains(process.ProcessName) || Tracks.SingleOrDefault(w => w.WindowHandle == process.MainWindowHandle) != null)
                {
                    process.Dispose();
                    continue;
                }

                var tracker = new TrackingProcess(process, _configuration, _directX, _reader, _history, _notificator);
                tracker.Start();

                Tracks.Add(tracker);
                process.Exited += (sender, e) =>
                {
                    var obj = Tracks.Select((w, i) => new { Index = i, Process = w }).Single(w => w.Process.WindowHandle == ((Process) sender).MainWindowHandle);
                    obj.Process.Dispose();

                    Tracks.RemoveAt(obj.Index);
                };
            }
        }
    }
}