using QuickCapture.Services.Interfaces;

using SharpDX.Direct3D;
using SharpDX.Direct3D11;

namespace QuickCapture.Services
{
    internal class DirectXService : IDirectXService
    {
        public Device Device { get; private set; }

        public void Initialize()
        {
            Device = new Device(DriverType.Hardware, DeviceCreationFlags.BgraSupport);
        }

        public void Dispose()
        {
            Device?.Dispose();
        }
    }
}