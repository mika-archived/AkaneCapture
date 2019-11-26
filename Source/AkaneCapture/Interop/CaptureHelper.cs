using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Graphics.Capture;

using AkaneCapture.Interop.WinRT;

namespace AkaneCapture.Interop
{
    internal static class CaptureHelper
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        public static GraphicsCaptureItem CreateItemForWindow(IntPtr hWnd)
        {
            try
            {
                var factory = WindowsRuntimeMarshal.GetActivationFactory(typeof(GraphicsCaptureItem));
                var interop = (IGraphicsCaptureItemInterop) factory;
                var iid = typeof(GraphicsCaptureItem).GetInterface("IGraphicsCaptureItem").GUID;
                var pointer = interop.CreateForWindow(hWnd, ref iid);
                var capture = Marshal.GetObjectForIUnknown(pointer) as GraphicsCaptureItem;
                Marshal.Release(pointer);

                return capture;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}