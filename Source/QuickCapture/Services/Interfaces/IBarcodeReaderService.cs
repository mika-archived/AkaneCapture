using System.Collections.Generic;
using System.Drawing;

namespace QuickCapture.Services.Interfaces
{
    internal interface IBarcodeReaderService
    {
        List<string> Read(Bitmap bitmap);
    }
}