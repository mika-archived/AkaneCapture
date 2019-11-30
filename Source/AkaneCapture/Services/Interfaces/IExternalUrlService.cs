using System;

namespace AkaneCapture.Services.Interfaces
{
    public interface IExternalUrlService
    {
        void OpenUrl(Uri url);
    }
}