using System;
using System.Diagnostics;

using AkaneCapture.Services.Interfaces;

namespace AkaneCapture.Services
{
    public class ExternalUrlService : IExternalUrlService
    {
        public void OpenUrl(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            try
            {
                Process.Start(new ProcessStartInfo(url.ToString()) { UseShellExecute = true });
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}