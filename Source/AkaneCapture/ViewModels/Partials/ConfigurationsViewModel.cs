using System;
using System.Reactive.Linq;

using AkaneCapture.Extensions;
using AkaneCapture.Mvvm;
using AkaneCapture.Services.Interfaces;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace AkaneCapture.ViewModels.Partials
{
    internal class ConfigurationsViewModel : ViewModel
    {
        public ReactiveProperty<long> CaptureFrames { get; }
        public ReactiveProperty<long> CaptureRate { get; }
        public ReadOnlyReactiveProperty<long> CaptureSeconds { get; }

        public ConfigurationsViewModel(IConfigurationService configuration)
        {
            CaptureFrames = configuration.ObserveProperty(w => w.CaptureFrames).ToReactiveProperty().AddTo(this);
            CaptureFrames.Subscribe(w => configuration.CaptureFrames = w).AddTo(this);
            CaptureRate = configuration.ObserveProperty(w => w.CaptureRate).ToReactiveProperty().AddTo(this);
            CaptureRate.Subscribe(w => configuration.CaptureRate = w).AddTo(this);
            CaptureSeconds = CaptureFrames.CombineLatest(CaptureRate, (a, b) => a * b).ToReadOnlyReactiveProperty().AddTo(this);
        }
    }
}