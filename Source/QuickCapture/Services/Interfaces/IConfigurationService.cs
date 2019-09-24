using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QuickCapture.Services.Interfaces
{
    internal interface IConfigurationService : INotifyPropertyChanged
    {
        ObservableCollection<string> TargetProcesses { get; }

        void Save();

        void Load();
    }
}