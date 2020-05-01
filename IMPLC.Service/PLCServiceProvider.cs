using IMPLC.Service.IPC;

namespace IMPLC.Service
{
    public sealed class PLCServiceProvider
    {
        public static IPLCService GetService(PLCServiceType serviceType)
        {
            switch (serviceType)
            {
                default:
                case PLCServiceType.IPC:
                    return new PLCService();
            }
        }

        public static IPLCServiceClient GetServiceClient(PLCServiceType serviceType)
        {
            switch (serviceType)
            {
                default:
                case PLCServiceType.IPC:
                    return new PLCServiceClient();
            }
        }
    }

}