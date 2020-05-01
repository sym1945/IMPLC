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

        public short BlockWrite(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            return (short)_DeviceRepo.WriteDeviceBlock(device, deviceNo, size, ref buf);
        }

        public short BlockRead(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            return (short)_DeviceRepo.ReadDeviceBlock(device, deviceNo, size, out buf);
        }

        public short SetBit(eDevice device, short devno, bool set)
        {
            return (short)_DeviceRepo.WriteBit(device, devno, set);
        }
    }
}