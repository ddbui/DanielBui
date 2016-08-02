using Prism.Mvvm;

namespace Emulator.UI.ViewModels
{
    /// <summary>
    /// MainWindowViewModel, view model for main window.
    /// BindableBase is something I've never seen before!
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Emulator";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
