using System.Collections.Generic;

namespace IMPLC.Service
{
    public interface IPLCServiceObject
    {
        int Open();

        int Close();

        int WriteBlock(int device, int deviceNo, int size, ref short[] buf);

        int ReadBlock(int device, int deviceNo, int size, ref short[] buf);

        int SetBit(int device, int devno, bool set);

        List<PLCServiceDeviceInfo> GetServiceDeviceInfo();
    }
}