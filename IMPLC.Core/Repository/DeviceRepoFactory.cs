namespace IMPLC.Core
{
    public class DeviceRepoFactory
    {
        public static IDeviceRepo MakeDeviceRepo(Device device, short length)
        {
            if (device.IsBitDevice())
                return new BitDeviceRepo(length);
            else
                return new WordDeviceRepo(length);
        }
    }
}