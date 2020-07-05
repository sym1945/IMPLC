namespace IMPLC.Core
{
    public interface IDeviceRepo
    {
        int Length { get; }

        ErrorCode ReadDeviceBlock(Device device, int address, int length, ref short[] readValues);

        ErrorCode WriteDeviceBlock(Device device, int address, int length, ref short[] writeValues);

        ErrorCode WriteBit(Device device, int address, bool value);

    }
}
