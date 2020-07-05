using IMPLC.Core;
using System;

namespace IMPLC.Service
{
    [Serializable]
    public class PLCServiceDeviceInfo
    {
        public Device Device { get; private set; }

        public int Length { get; private set; }

        public PLCServiceDeviceInfo(Device device, int length)
        {
            Device = device;
            Length = length;
        }
    }
}