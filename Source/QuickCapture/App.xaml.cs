using System.Windows;

using Prism.Ioc;
using Prism.Unity;

using QuickCapture.Services;
using QuickCapture.Services.Interfaces;
using QuickCapture.Views;

namespace QuickCapture
{
    /// <summary>
    ///     App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // こんな面倒なことしないとダメだったっけ...？
            var configuration = new ConfigurationService();
            var directX = new DirectXService();
            var reader = new QrCodeReaderService();
            var history = new ReadingHistoryService();
            containerRegistry.RegisterInstance<IConfigurationService>(configuration);
            containerRegistry.RegisterInstance<IDirectXService>(directX);
            containerRegistry.RegisterInstance<IExternalUrlService>(new ExternalUrlService());
            containerRegistry.RegisterInstance<IQrCodeReaderService>(reader);
            containerRegistry.RegisterInstance<IReadingHistoryService>(history);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            var configuration = Container.Resolve<IConfigurationService>();
            configuration.Load();

            var directX = Container.Resolve<IDirectXService>();
            directX.Initialize();


            var history = Container.Resolve<IReadingHistoryService>();
            history.Load();

            base.InitializeShell(shell);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var configuration = Container.Resolve<IConfigurationService>();
            configuration.Save();


            var history = Container.Resolve<IReadingHistoryService>();
            history.Save();

            base.OnExit(e);
        }
    }
}