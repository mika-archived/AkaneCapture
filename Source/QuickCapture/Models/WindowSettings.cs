using System.Configuration;
using System.Windows;

using QuickCapture.Interop.Win32;

namespace QuickCapture.Models
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