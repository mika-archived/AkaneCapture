using System;
using System.Diagnostics;

using QuickCapture.Services.Interfaces;

namespace QuickCapture.Services
{
    public class ExternalUrlService : IExternalUrlService
    {
        public void OpenUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
                Process.Start(url);
            else
                throw new InvalidOperationException();
        }
    }
}