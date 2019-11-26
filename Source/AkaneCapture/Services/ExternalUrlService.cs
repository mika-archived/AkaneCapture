using System;
using System.Diagnostics;

using AkaneCapture.Services.Interfaces;

namespace AkaneCapture.Services
{
    public class ExternalUrlService : IExternalUrlService
    {
        public void OpenUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
                try
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            else
                throw new InvalidOperationException();
        }
    }
}