namespace IMPLC.Core
{
    public interface IDeviceRepo
    {
        ErrorCode ReadDeviceBlock(eDevice device, short address, short length, out short[] readValues);

        ErrorCode WriteDeviceBlock(eDevice device, short address, short length, ref short[] writeValues);

        ErrorCode WriteBit(eDevice device, short address, bool value);

    }
}
