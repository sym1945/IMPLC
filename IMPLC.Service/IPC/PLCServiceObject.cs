using IMPLC.Core;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return (short)_DeviceRepo.WriteDeviceBlock((Device)device, deviceNo, size, ref buf);
        }

        public short ReadBlock(short device, short deviceNo, short size, ref short[] buf)
        {
            return (short)_DeviceRepo.ReadDeviceBlock((Device)device, deviceNo, size, out buf);
        }

        public short SetBit(short device, short devno, bool set)
        {
            return (short)_DeviceRepo.WriteBit((Device)device, devno, set);
        }

        public List<PLCServiceDeviceInfo> GetServiceDeviceInfo()
        {
            return _DeviceRepo.Devices.Select(d => new PLCServiceDeviceInfo(d.Key, d.Value.Length)).ToList();
        }
    }
}