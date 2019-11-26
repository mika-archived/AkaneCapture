using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

using AkaneCapture.Services.Interfaces;

namespace AkaneCapture.Services
{
    internal class ToastNotificationService : IToastNotificationService
    {
        public void Show(string content)
        {
            var xml = new XmlDocument();
            xml.LoadXml(content);

            var toast = new ToastNotification(xml);
            ToastNotificationManager.CreateToastNotifier("moe.mochizuki.QuickCapture").Show(toast);
        }
    }
}