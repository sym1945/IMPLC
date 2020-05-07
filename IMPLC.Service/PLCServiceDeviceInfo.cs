using IMPLC.Core;
using System;

namespace IMPLC.Service
{
    [Serializable]
    public class PLCServiceDeviceInfo
    {
        public Device Device { get; private set; }

        public short Length { get; private set; }

        public PLCServiceDeviceInfo(Device device, short length)
        {
            Device = device;
            Length = length;
        }
    }
}