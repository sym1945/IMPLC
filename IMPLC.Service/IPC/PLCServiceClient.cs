using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace IMPLC.Service.IPC
{
    public class PLCServiceClient : IPLCServiceClient
    {
        private IpcChannel _Channel;

        public IPLCServiceObject Connect(string rootUri)
        {
            try
            {
                if (_Channel != null)
                    ChannelServices.UnregisterChannel(_Channel);

                _Channel = new IpcChannel();

                ChannelServices.RegisterChannel(_Channel, true);

                var remoteType = new WellKnownClientTypeEntry(
                    typeof(PLCServiceObject)
                    , $@"{rootUri}/{nameof(PLCServiceObject)}.rem");

                RemotingConfiguration.RegisterWellKnownClientType(remoteType);

                IPLCServiceObject serviceObject = new PLCServiceObject();
                serviceObject.Open();

                return serviceObject;
            }
            catch
            {
                return null;
            }
        }

        public bool Disconnect()
        {
            try
            {
                if (_Channel != null)
                {
                    ChannelServices.UnregisterChannel(_Channel);
                    _Channel = null;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}