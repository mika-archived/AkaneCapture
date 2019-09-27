using System.Collections.ObjectModel;

using QuickCapture.Models.ReadingResults;

namespace QuickCapture.Services.Interfaces
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