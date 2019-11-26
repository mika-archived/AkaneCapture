using System.Reactive.Linq;

using AkaneCapture.Extensions;
using AkaneCapture.Mvvm;
using AkaneCapture.Services.Interfaces;

using Reactive.Bindings;

namespace AkaneCapture.ViewModels.Partials
{
    internal class CaptureTargetsViewModel : ViewModel
    {
        public ReadOnlyReactiveCollection<string> CaptureTargets { get; }
        public ReactiveProperty<string> SelectedItem { get; set; }
        public ReactiveProperty<string> CaptureTarget { get; set; }
        public ReactiveCommand AddCaptureTargetCommand { get; set; }
        public ReactiveCommand RemoveCaptureTargetCommand { get; set; }
        public ReactiveCommand SelectCaptureTargetCommand { get; set; }

        public CaptureTargetsViewModel(IConfigurationService configuration)
        {
            CaptureTargets = configuration.TargetProcesses.ToReadOnlyReactiveCollection().AddTo(this);
            SelectedItem = new ReactiveProperty<string>().AddTo(this);
            CaptureTarget = new ReactiveProperty<string>().AddTo(this);
            AddCaptureTargetCommand = CaptureTarget.Select(w => !string.IsNullOrWhiteSpace(w)).ToReactiveCommand().AddTo(this);
            AddCaptureTargetCommand.Subscribe(() =>
            {
                configuration.TargetProcesses.Add(CaptureTarget.Value);
                CaptureTarget.Value = "";
            }).AddTo(this);
            RemoveCaptureTargetCommand = SelectedItem.Select(w => !string.IsNullOrWhiteSpace(w)).ToReactiveCommand().AddTo(this);
            RemoveCaptureTargetCommand.Subscribe(() => configuration.TargetProcesses.Remove(SelectedItem.Value)).AddTo(this);
            SelectCaptureTargetCommand = new ReactiveCommand().AddTo(this);
            SelectCaptureTargetCommand.Subscribe(() => { }).AddTo(this);
        }
    }
}