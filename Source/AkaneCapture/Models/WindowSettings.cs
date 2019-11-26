using System.Configuration;
using System.Windows;

using AkaneCapture.Interop.Win32;

namespace AkaneCapture.Models
{
    internal class WindowSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        public WINDOWPLACEMENT? WindowPlacement
        {
            get => (WINDOWPLACEMENT?) this[nameof(WindowPlacement)];
            set => this[nameof(WindowPlacement)] = value;
        }

        public WindowSettings(Window window) : base(window.GetType().FullName) { }
    }
}