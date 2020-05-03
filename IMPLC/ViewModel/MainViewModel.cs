using System.Windows.Input;

namespace IMPLC
{
    public class MainViewModel : ViewModelBase
    {
        public ServiceViewModel ServiceViewModel { get; private set; }

        public bool ShowSettingMenu { get; set; }

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


        public MainViewModel()
        {
            ServiceViewModel = new ServiceViewModel();
        }
    }
}