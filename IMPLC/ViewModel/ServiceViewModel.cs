using IMPLC.Service;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace IMPLC
{
    public class ServiceViewModel : ViewModelBase
    {
        private readonly LogViewModel _Logger = LogViewModel.Instance;

        private bool _IsRunning;
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

        

        public bool IsRunning 
        {
            get => _IsRunning;
            private set
            {
                if (_IsRunning == value)
                    return;

                _IsRunning = value;

                _StartCommand.OnCanExecuteChanged();
                _StopCommand.OnCanExecuteChanged();
            }
        }

        public string RootUri { get; set; }

     

        public ICommand StartCommand
        {
            get => _StartCommand ?? (_StartCommand = new CommandBase
            {
                CanExecuteFunction = (param) => 
                {
                    return !_IsRunning;
                },

                ExecuteAction = (param) => 
                {
                    if (_Service != null || _IsRunning)
                    {
                        _Logger.AddLog("Service is already Started");
                        return;
                    }

                    _Service = PLCServiceProvider.GetService(SelectedServiceType);
                    var result = _Service.Start(RootUri);
                    IsRunning = result;
                    if (_IsRunning == false)
                        _Service = null;

                    _Logger.AddLog($"{ServiceUri} IMPLC Service {(result ? "Start!" : "Start Fail!!")}");
                }
            });
        }

        public ICommand StopCommand
        {
            get => _StopCommand ?? (_StopCommand = new CommandBase
            {
                CanExecuteFunction = (param) =>
                {
                    return _IsRunning;
                },

                ExecuteAction = (param) =>
                {
                    if (_Service == null || !_IsRunning)
                    {
                        _Logger.AddLog("Service is not Started");
                        return;
                    }

                    var result = _Service.Stop();
                    IsRunning = !result;
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


        

    }
}