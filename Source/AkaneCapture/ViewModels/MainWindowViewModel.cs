using AkaneCapture.Extensions;
using AkaneCapture.Mvvm;
using AkaneCapture.Services.Interfaces;
using AkaneCapture.ViewModels.Partials;

namespace AkaneCapture.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public string Title => "AkaneCapture";

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