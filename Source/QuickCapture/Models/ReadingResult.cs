using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuickCapture.Models
{
    internal class ReadingResult
    {
        [JsonProperty("record_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime RecordAt { get; set; }

        [JsonProperty("situation")]
        public string Situation { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}