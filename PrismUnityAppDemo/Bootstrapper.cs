using Microsoft.Practices.Unity;
using Prism.Unity;
using PrismUnityAppDemo.Views;
using System.Windows;

namespace PrismUnityAppDemo
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
