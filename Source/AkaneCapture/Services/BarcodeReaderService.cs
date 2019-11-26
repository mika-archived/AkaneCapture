using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

using AkaneCapture.Services.Interfaces;

using ZXing;

namespace AkaneCapture.Services
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
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            var decoded = _reader.DecodeMultiple(ms.GetBuffer());
            return decoded?.Select(w => w.Text).ToList() ?? new List<string>();
        }
    }
}