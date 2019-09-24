using System.Collections.ObjectModel;
using System.Diagnostics;

using QuickCapture.Models;

namespace QuickCapture.Services.Interfaces
{
    internal interface IProcessTrackerService
    {
        ObservableCollection<TrackingProcess> Tracks { get; }

        void StartTrack();

        void StopTrack();
    }
}