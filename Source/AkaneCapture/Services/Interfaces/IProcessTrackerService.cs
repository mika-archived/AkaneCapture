using System.Collections.ObjectModel;

using AkaneCapture.Models;

namespace AkaneCapture.Services.Interfaces
{
    internal interface IProcessTrackerService
    {
        ObservableCollection<TrackingProcess> Tracks { get; }

        void StartTrack();

        void StopTrack();
    }
}