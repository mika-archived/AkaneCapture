using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using QuickCapture.Services.Interfaces;

using ZXing;

namespace QuickCapture.Services
{
    internal class BarcodeReaderService : IBarcodeReaderService
    {
        private readonly BarcodeReader _reader;

        public BarcodeReaderService()
        {
            _reader = new BarcodeReader { AutoRotate = true, TryInverted = true, Options = { PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE } } };
        }

        public List<string> Read(Bitmap bitmap)
        {
            var decoded = _reader.DecodeMultiple(bitmap);
            return decoded?.Select(w => w.Text).ToList() ?? new List<string>();
        }
    }
}