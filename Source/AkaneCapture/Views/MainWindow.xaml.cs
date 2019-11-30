using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

using AkaneCapture.Interop.Win32;
using AkaneCapture.Models;

namespace AkaneCapture.Views
{
    /// <summary>
    ///     MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowSettings _settings;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            _settings = new WindowSettings(this);
            _settings.Upgrade();
            _settings.Reload();

            if (!_settings.WindowPlacement.HasValue)
                return;

            var hWnd = new WindowInteropHelper(this).Handle;
            var placement = _settings.WindowPlacement.Value;
            placement.Length = Marshal.SizeOf<WINDOWPLACEMENT>();
            placement.Flags = 0;
            placement.ShowCmd = ShowWindowCommands.Normal;

            NativeMethods.SetWindowPlacement(hWnd, ref placement);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            base.OnClosing(e);

            if (e.Cancel)
                return;

            var hWnd = new WindowInteropHelper(this).Handle;
            NativeMethods.GetWindowPlacement(hWnd, out var placement);

            _settings.WindowPlacement = placement;
            _settings.Save();
        }
    }
}