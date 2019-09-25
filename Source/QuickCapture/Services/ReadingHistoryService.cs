using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using QuickCapture.Models;
using QuickCapture.Services.Interfaces;

using Reactive.Bindings;

namespace QuickCapture.Services
{
    internal class ReadingHistoryService : IReadingHistoryService
    {
        private readonly ObservableCollection<ReadingResult> _history;

        public ReadingHistoryService()
        {
            _history = new ObservableCollection<ReadingResult>();
        }

        public ReadOnlyObservableCollection<ReadingResult> History => _history.ToReadOnlyReactiveCollection();

        public void Load()
        {
            if (!File.Exists(Constants.HistoryFilePath))
                return;

            using var stream = new FileStream(Constants.HistoryFilePath, FileMode.Open);
            using var reader = new StreamReader(stream);
            var history = JsonConvert.DeserializeObject<IEnumerable<ReadingResult>>(reader.ReadToEnd());
            _history.AddRange(history);
        }

        public void Append(ReadingResult result)
        {
            _history.Insert(0, result);
        }

        public void Clear()
        {
            _history.Clear();
        }

        public void Save()
        {
            if (!Directory.Exists(Constants.ApplicationDir))
                Directory.CreateDirectory(Constants.ApplicationDir);

            using var stream = new FileStream(Constants.HistoryFilePath, File.Exists(Constants.HistoryFilePath) ? FileMode.Truncate : FileMode.Create);
            using var writer = new StreamWriter(stream);
            var json = JsonConvert.SerializeObject(_history.ToList());
            writer.Write(json);
        }
    }
}