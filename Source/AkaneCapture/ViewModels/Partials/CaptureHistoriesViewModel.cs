using AkaneCapture.Extensions;
using AkaneCapture.Mvvm;
using AkaneCapture.Services.Interfaces;
using AkaneCapture.ViewModels.Items;

using Reactive.Bindings;

namespace AkaneCapture.ViewModels.Partials
{
    internal class CaptureHistoriesViewModel : ViewModel
    {
        public ReadOnlyReactiveCollection<CaptureHistoryViewModel> Histories { get; set; }

        public CaptureHistoriesViewModel(IExternalUrlService urlService, IReadingHistoryService histories)
        {
            Histories = histories.History.ToReadOnlyReactiveCollection(w => CaptureHistoryViewModel.Create(w, urlService).AddTo(this)).AddTo(this);
        }
    }
}