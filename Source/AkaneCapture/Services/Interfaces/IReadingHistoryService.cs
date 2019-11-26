using System.Collections.ObjectModel;

using AkaneCapture.Models.ReadingResults;

namespace AkaneCapture.Services.Interfaces
{
    internal interface IReadingHistoryService
    {
        ReadOnlyObservableCollection<ResultBase> History { get; }

        void Load();

        void Append(ResultBase result);

        void Clear();

        void Save();
    }
}