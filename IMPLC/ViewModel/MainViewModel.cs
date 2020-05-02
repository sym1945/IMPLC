namespace IMPLC
{
    public class MainViewModel
    {
        public ServiceViewModel ServiceViewModel { get; private set; }


        public MainViewModel()
        {
            ServiceViewModel = new ServiceViewModel();
        }
    }
}