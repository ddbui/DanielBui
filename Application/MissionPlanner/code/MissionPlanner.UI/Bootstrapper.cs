using System.Windows;
using Prism.Logging;
using Prism.Unity;

namespace MissionPlanner.UI
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override ILoggerFacade CreateLogger()
        {
            return null;
        }

        protected override DependencyObject CreateShell()
        {
            return new ShellWindow();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = this.Shell as Window;
            App.Current.MainWindow.Show();
        }
    }
}
