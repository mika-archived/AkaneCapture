using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AkaneCapture.Services.Interfaces
{
    internal interface IConfigurationService : INotifyPropertyChanged
    {
        ObservableCollection<string> TargetProcesses { get; }

        long CaptureFrames { get; set; }

        long CaptureRate { get; set; }

        void Save();

        void Load();
    }
}