using IMPLC.Core;

namespace IMPLC.Service
{
    public interface IPLCServiceObject
    {
        short Open();

        short Close();

        short WriteBlock(short device, short deviceNo, short size, ref short[] buf);

        short ReadBlock(short device, short deviceNo, short size, ref short[] buf);

        short SetBit(short device, short devno, bool set);
    }
}