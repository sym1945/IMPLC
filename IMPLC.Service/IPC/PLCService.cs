using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace IMPLC.Service.IPC
{
    public class PLCService : IPLCService
    {
        private IpcChannel _ServerChannel;

        public bool Start(string portName)
        {
            try
            {
                if (_ServerChannel != null)
                    return false;

                _ServerChannel = new IpcChannel(portName);
                ChannelServices.RegisterChannel(_ServerChannel, true);

                RemotingConfiguration.RegisterWellKnownServiceType(typeof(PLCServiceObject)
                , $"{nameof(PLCServiceObject)}.rem"
                , WellKnownObjectMode.Singleton);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                if (_ServerChannel == null)
                    return false;

                ChannelServices.UnregisterChannel(_ServerChannel);
                _ServerChannel = null;

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}