using Microsoft.Practices.Unity;
using Prism.Unity;
using Emulator.UI.Views;
using System.Windows;
using Prism.Logging;
using Emulator.Logging;

namespace Emulator.UI
{
    /// <summary>
    /// Bootstrapper
    /// </summary>
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
}
