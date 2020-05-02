using IMPLC.Core;
using System.ComponentModel;

namespace IMPLC.Service
{
    public enum PLCServiceType
    {
        [Description("ipc://")]
        IPC,
    }


    public static class PLCServiceTypeExtension
    {
        public static string GetProtocolString(this PLCServiceType serviceType)
        {
            return serviceType.GetEnumDescription();
        }
    }
}