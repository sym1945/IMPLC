namespace IMPLC.Core
{
    public interface IDeviceRepo
    {
        short Length { get; }

        ErrorCode ReadDeviceBlock(Device device, short address, short length, ref short[] readValues);

        ErrorCode WriteDeviceBlock(Device device, short address, short length, ref short[] writeValues);

        ErrorCode WriteBit(Device device, short address, bool value);

    }
}
