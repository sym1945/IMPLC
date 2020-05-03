using IMPLC.Service;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace IMPLC
{
    public class ServiceViewModel : ViewModelBase
    {
        private readonly LogViewModel _Logger = LogViewModel.Instance;

        private IPLCService _Service;
        private CommandBase _StartCommand;
        private CommandBase _StopCommand;


        public string ServiceUri => $"{SelectedServiceType.GetProtocolString()}{RootUri}";


        public IEnumerable<PLCServiceType> ServiceTypes
        {
            get => new List<PLCServiceType>
            {
                PLCServiceType.IPC
            };
        }

        public PLCServiceType SelectedServiceType { get; set; }

        

        public bool IsRunning { get; private set; }

        public string RootUri { get; set; }

     

        public ICommand StartCommand
        {
            get => _StartCommand ?? (_StartCommand = new CommandBase
            {
                CanExecuteFunction = (param) => 
                {
                    return !IsRunning;
                },

                ExecuteAction = (param) => 
                {
                    if (_Service != null || IsRunning)
                    {
                        _Logger.AddLog("Service is already Started");
                        return;
                    }

                    _Service = PLCServiceProvider.GetService(SelectedServiceType);
                    var uri = ServiceUri;
                    var result = _Service.Start(uri);
                    IsRunning = result;
                    OnServiceRunningChanged();

                    _Logger.AddLog($"{uri} IMPLC Service {(result ? "Start!" : "Start Fail!!")}");
                }
            });
        }

        public ICommand StopCommand
        {
            get => _StopCommand ?? (_StopCommand = new CommandBase
            {
                CanExecuteFunction = (param) =>
                {
                    return IsRunning;
                },

                ExecuteAction = (param) =>
                {
                    if (_Service == null || !IsRunning)
                    {
                        _Logger.AddLog("Service is not Started");
                        return;
                    }

                    var result = _Service.Stop();
                    IsRunning = !result;
                    OnServiceRunningChanged();
                    _Service = null;

                    _Logger.AddLog($"{ServiceUri} IMPLC Service {(result ? "Stop!" : "Stop Fail!!")}");
                }
            });
        }


        public ServiceViewModel()
        {
            SelectedServiceType = ServiceTypes.FirstOrDefault();
            RootUri = "localhost:9090";
        }


        private void OnServiceRunningChanged()
        {
            _StartCommand.OnCanExecuteChanged();
            _StopCommand.OnCanExecuteChanged();
        }

    }
}