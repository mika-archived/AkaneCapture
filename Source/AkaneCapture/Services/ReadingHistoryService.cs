using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using AkaneCapture.Models;
using AkaneCapture.Models.ReadingResults;
using AkaneCapture.Services.Interfaces;

using Newtonsoft.Json;

using Reactive.Bindings;

namespace AkaneCapture.Services
{
    internal class ReadingHistoryService : IReadingHistoryService
    {
        private readonly ObservableCollection<ResultBase> _history;
        private readonly JsonSerializerSettings _settings;

        public ReadingHistoryService()
        {
            _history = new ObservableCollection<ResultBase>();
            _settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
        }

        public ReadOnlyObservableCollection<ResultBase> History => _history.ToReadOnlyReactiveCollection();

        public void Load()
        {
            if (!File.Exists(Constants.HistoryFilePath))
                return;

            using var stream = new FileStream(Constants.HistoryFilePath, FileMode.Open);
            using var reader = new StreamReader(stream);
            var history = JsonConvert.DeserializeObject<IEnumerable<ResultBase>>(reader.ReadToEnd(), _settings);
            _history.AddRange(history);
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
            var json = JsonConvert.SerializeObject(_history.ToList(), _settings);
            writer.Write(json);
        }

        public void Append(ResultBase result)
        {
            _history.Insert(0, result);
        }
    }
}