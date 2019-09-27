using QuickCapture.Extensions;
using QuickCapture.Mvvm;
using QuickCapture.Services.Interfaces;
using QuickCapture.ViewModels.Items;

using Reactive.Bindings;

namespace QuickCapture.ViewModels.Partials
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