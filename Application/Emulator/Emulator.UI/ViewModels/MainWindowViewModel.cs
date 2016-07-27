using Prism.Mvvm;

namespace Emulator.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Emulator Application";
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
