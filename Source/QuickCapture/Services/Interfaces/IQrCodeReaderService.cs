using System.Collections.Generic;
using System.Drawing;

namespace QuickCapture.Services.Interfaces
{
    internal interface IQrCodeReaderService
    {
        List<string> Read(Bitmap bitmap);
    }
}