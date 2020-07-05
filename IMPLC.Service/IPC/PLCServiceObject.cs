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

        public int Open()
        {
            return 0;
        }

        public int Close()
        {
            return 0;
        }

        public int WriteBlock(int device, int deviceNo, int size, ref short[] buf)
        {
            return (int)_DeviceRepo.WriteDeviceBlock((Device)device, deviceNo, size, ref buf);
        }

        public int ReadBlock(int device, int deviceNo, int size, ref short[] buf)
        {
            return (int)_DeviceRepo.ReadDeviceBlock((Device)device, deviceNo, size, ref buf);
        }

        public int SetBit(int device, int devno, bool set)
        {
            return (int)_DeviceRepo.WriteBit((Device)device, devno, set);
        }

        public List<PLCServiceDeviceInfo> GetServiceDeviceInfo()
        {
            return _DeviceRepo.Devices.Select(d => new PLCServiceDeviceInfo(d.Key, d.Value.Length)).ToList();
        }
    }
}