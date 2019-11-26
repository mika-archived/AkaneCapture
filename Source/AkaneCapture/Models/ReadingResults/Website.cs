using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

using Newtonsoft.Json;

namespace AkaneCapture.Models.ReadingResults
{
    internal class Website : ResultBase
    {
        private bool _isFilled;

        public override async Task FillAsync()
        {
            if (_isFilled)
                return;
            _isFilled = true;

            try
            {
                using var client = new HttpClient();
                using var response = await client.GetAsync(Text);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var parser = new HtmlParser();
                var document = parser.ParseDocument(content);

                var title = document.QuerySelector("meta[property='og:title']");
                Title = title != null ? ((IHtmlMetaElement) title).Content : document.Title;

                var thumbnail = document.QuerySelector("meta[property='og:image']");
                ThumbnailUrl = ((IHtmlMetaElement) thumbnail)?.Content ?? "https://via.placeholder.com/72.png?text=No%20Imge";
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        #region ThumbnailUrl

        private string _thumbnailUrl;

        [JsonIgnore]
        public string ThumbnailUrl
        {
            get => _thumbnailUrl;
            set
            {
                if (_thumbnailUrl != value)
                    SetProperty(ref _thumbnailUrl, value);
            }
        }

        #endregion

        #region Title

        private string _title;

        [JsonIgnore]
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                    SetProperty(ref _title, value);
            }
        }

        #endregion
    }
}