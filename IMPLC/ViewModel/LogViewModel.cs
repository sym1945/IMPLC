using System.Collections.ObjectModel;

namespace IMPLC
{
    public class LogViewModel : ViewModelBase
    {
        private const int MAX_LOG_COUNT = 50;

        public static LogViewModel Instance { get; private set; }

        public ObservableCollection<string> Logs { get; private set; }


        static LogViewModel()
        {
            Instance = new LogViewModel();
        }

        public LogViewModel()
        {
            Logs = new ObservableCollection<string>();
        }

        public void AddLog(string logText)
        {
            if (Logs.Count >= MAX_LOG_COUNT)
                Logs.RemoveAt(0);

            Logs.Add(logText);
        }


    }
}