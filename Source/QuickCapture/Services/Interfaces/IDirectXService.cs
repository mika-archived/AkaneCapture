using SharpDX.Direct3D11;

namespace QuickCapture.Services.Interfaces
{
    internal interface IDirectXService
    {
        Device Device { get; }

        void Initialize();
    }
}