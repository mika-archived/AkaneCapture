using System;

using SharpDX.Direct3D11;

namespace AkaneCapture.Services.Interfaces
{
    internal interface IDirectXService : IDisposable
    {
        Device Device { get; }

        void Initialize();
    }
}