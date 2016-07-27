using Microsoft.Practices.Unity;
using Prism.Unity;
using Emulator.UI.Views;
using System.Windows;

namespace Emulator.UI
{
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
    }
}
