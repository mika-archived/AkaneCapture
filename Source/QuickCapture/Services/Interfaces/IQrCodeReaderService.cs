using System.Drawing;

namespace QuickCapture.Services.Interfaces
{
    internal interface IQrCodeReaderService
    {
        string Read(Bitmap bitmap);
    }
}