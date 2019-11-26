using System.Collections.Generic;
using System.Drawing;

namespace AkaneCapture.Services.Interfaces
{
    internal interface IBarcodeReaderService
    {
        List<string> Read(Bitmap bitmap);
    }
}