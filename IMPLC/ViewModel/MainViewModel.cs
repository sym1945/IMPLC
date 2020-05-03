using System.Windows;
using System.Windows.Input;

namespace IMPLC
{
    public class MainViewModel : ViewModelBase
    {
        public ServiceViewModel ServiceViewModel { get; private set; }

        public string Title => $"IMPLC{(ServiceViewModel.IsRunning ? $" - {ServiceViewModel.ServiceUri}" : "")}";


        public bool ShowSettingMenu { get; set; }

        public bool IsHidding { get; set; }
    

        public ICommand ShowSettingMenuCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    ShowSettingMenu = !ShowSettingMenu;
                }
            };
        }

        public ICommand HideWindowCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    IsHidding = true;
                }
            };
        }

        public ICommand ShowWindowCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    IsHidding = false;
                }
            };
        }

        public ICommand ExitWindowCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    Application.Current.Shutdown();
                }
            };
        }


        public MainViewModel()
        {
            ServiceViewModel = new ServiceViewModel();
            ServiceViewModel.PropertyChanged += (sender, e) => OnPropertyChanged(nameof(Title));
        }

    }
}