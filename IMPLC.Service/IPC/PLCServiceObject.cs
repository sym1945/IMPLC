using IMPLC.Core;
using System;

namespace IMPLC.Service.IPC
{
    public class PLCServiceObject : MarshalByRefObject, IPLCServiceObject
    {
        private readonly DeviceRepoManager _DeviceRepo = DeviceRepoManager.Instance;

        public PLCServiceObject()
        { 
        }

        public short Open()
        {
            return 0;
        }

        public short Close()
        {
            return 0;
        }

        public short WriteBlock(short device, short deviceNo, short size, ref short[] buf)
        {
            return (short)_DeviceRepo.WriteDeviceBlock((eDevice)device, deviceNo, size, ref buf);
        }

        public short ReadBlock(short device, short deviceNo, short size, ref short[] buf)
        {
            return (short)_DeviceRepo.ReadDeviceBlock((eDevice)device, deviceNo, size, out buf);
        }

        public short SetBit(short device, short devno, bool set)
        {
            return (short)_DeviceRepo.WriteBit((eDevice)device, devno, set);
        }
    }
}