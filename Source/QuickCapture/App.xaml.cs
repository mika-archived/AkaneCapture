using System.Windows;

using Prism.Ioc;
using Prism.Unity;

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
            containerRegistry.RegisterInstance<IConfigurationService>(configuration);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            var configuration = Container.Resolve<IConfigurationService>();
            configuration.Load();

            base.InitializeShell(shell);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            var configuration = Container.Resolve<IConfigurationService>();
            configuration.Save();


            base.OnExit(e);
        }
    }
}