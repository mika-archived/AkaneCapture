using QuickCapture.Mvvm;
using QuickCapture.Services.Interfaces;
using QuickCapture.ViewModels.Items;

using Reactive.Bindings;

namespace QuickCapture.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public string Title => "QuickCapture";

        public ReadOnlyReactiveCollection<CaptureHistoryViewModel> History { get; }

        public MainWindowViewModel(IReadingHistoryService history)
        {
            History = history.History.ToReadOnlyReactiveCollection(w => new CaptureHistoryViewModel(w));
        }
    }
}