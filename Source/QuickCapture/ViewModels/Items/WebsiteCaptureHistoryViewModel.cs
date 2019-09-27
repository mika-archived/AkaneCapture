using System;

using QuickCapture.Extensions;
using QuickCapture.Models.ReadingResults;
using QuickCapture.Services.Interfaces;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace QuickCapture.ViewModels.Items
{
    internal class WebsiteCaptureHistoryViewModel : CaptureHistoryViewModel
    {
        public ReadOnlyReactiveProperty<string> Thumbnail { get; }
        public ReadOnlyReactiveProperty<string> Title { get; }
        public ReactiveCommand FillCommand { get; }
        public ReactiveCommand OpenHyperlinkCommand { get; }

        public WebsiteCaptureHistoryViewModel(Website website, IExternalUrlService urlService) : base(website)
        {
            Thumbnail = website.ObserveProperty(w => w.ThumbnailUrl).ToReadOnlyReactiveProperty().AddTo(this);
            Title = website.ObserveProperty(w => w.Title).ToReadOnlyReactiveProperty().AddTo(this);
            FillCommand = new ReactiveCommand();
            FillCommand.Subscribe(async _ => await website.FillAsync()).AddTo(this);
            OpenHyperlinkCommand = new ReactiveCommand();
            OpenHyperlinkCommand.Subscribe(() => urlService.OpenUrl(Text)).AddTo(this);
        }
    }
}