using System;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Prism.Mvvm;

namespace QuickCapture.Models.ReadingResults
{
    internal abstract class ResultBase : BindableBase
    {
        [JsonProperty("record_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime RecordAt { get; set; }

        [JsonProperty("situation")]
        public string Situation { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public abstract Task FillAsync();

        public static ResultBase CreateFromText(string text, DateTime datetime, string path)
        {
            if (Uri.IsWellFormedUriString(text, UriKind.Absolute))
                return new Website { RecordAt = datetime, Situation = path, Text = text };
            return new Others { RecordAt = datetime, Situation = path, Text = text };
        }
    }
}