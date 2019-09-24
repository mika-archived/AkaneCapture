using System;
using System.Runtime.InteropServices;

namespace QuickCapture.Interop.Win32
{
    internal static class NativeMethods
    {
        #region User32

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, [Out] out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        #endregion
    }
}