using System.Collections.ObjectModel;

using QuickCapture.Models;

namespace QuickCapture.Services.Interfaces
{
    internal interface IReadingHistoryService
    {
        ReadOnlyObservableCollection<ReadingResult> History { get; }

        void Load();

        void Append(ReadingResult result);

        void Clear();

        void Save();
    }
}