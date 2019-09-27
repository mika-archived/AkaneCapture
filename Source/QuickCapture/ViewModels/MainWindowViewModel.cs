using QuickCapture.Extensions;
using QuickCapture.Mvvm;
using QuickCapture.Services.Interfaces;
using QuickCapture.ViewModels.Partials;

namespace QuickCapture.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public string Title => "QuickCapture";

        public CaptureHistoriesViewModel CaptureHistoriesViewModel { get; }
        public CaptureTargetsViewModel CaptureTargetsViewModel { get; }
        public ConfigurationsViewModel ConfigurationsViewModel { get; set; }

        public MainWindowViewModel(IConfigurationService configuration, IExternalUrlService urlService, IReadingHistoryService histories)
        {
            CaptureHistoriesViewModel = new CaptureHistoriesViewModel(urlService, histories).AddTo(this);
            CaptureTargetsViewModel = new CaptureTargetsViewModel(configuration).AddTo(this);
            ConfigurationsViewModel = new ConfigurationsViewModel(configuration).AddTo(this);
        }
    }
}