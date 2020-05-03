using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace IMPLC.Service.IPC
{
    public class PLCServiceClient : IPLCServiceClient
    {
        public IPLCServiceObject Connect(string rootUri)
        {
            try
            {
                var channel = new IpcChannel();

                ChannelServices.RegisterChannel(channel, true);

                var remoteType = new WellKnownClientTypeEntry(
                    typeof(PLCServiceObject)
                    , $@"{rootUri}/{nameof(PLCServiceObject)}.rem");

                RemotingConfiguration.RegisterWellKnownClientType(remoteType);

                IPLCServiceObject serviceObject = new PLCServiceObject();
                serviceObject.Open();

                return serviceObject;
            }
            catch(System.Exception ex)
            {
                return null;
            }
        }


    }
}