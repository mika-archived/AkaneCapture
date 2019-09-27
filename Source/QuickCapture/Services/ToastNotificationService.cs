using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

using QuickCapture.Services.Interfaces;

namespace QuickCapture.Services
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