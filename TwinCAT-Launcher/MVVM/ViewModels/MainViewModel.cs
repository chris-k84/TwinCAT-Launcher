using TwinCAT_Launcher.Core;

namespace TwinCAT_Launcher.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public ProjectViewModel ProjectVM { get; set; }
        public ADSViewModel ADSVM { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AdsViewCommand { get; set; }
        public RelayCommand ProjectViewCommand { get; set; }

        public MainViewModel()
        {
            ProjectVM = new ProjectViewModel();
            ADSVM = new ADSViewModel();
            _currentView = ProjectVM;
            AdsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ADSVM;
            });
            ProjectViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProjectVM;
            });
        }

    }
}
