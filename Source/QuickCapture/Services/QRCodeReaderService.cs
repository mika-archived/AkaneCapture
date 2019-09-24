using System.Drawing;

using QuickCapture.Services.Interfaces;

using ZXing;

namespace QuickCapture.Services
{
    internal class QrCodeReaderService : IQrCodeReaderService
    {
        private readonly BarcodeReader _reader;

        public QrCodeReaderService()
        {
            _reader = new BarcodeReader { AutoRotate = true, TryInverted = true };
        }

        public string Read(Bitmap bitmap)
        {
            var decoded = _reader.Decode(bitmap);
            return decoded?.Text;
        }
    }
}