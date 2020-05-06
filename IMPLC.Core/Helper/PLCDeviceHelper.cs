namespace IMPLC.Core
{
    public static class PLCDeviceHelper
    {
        public static bool IsBitDevice(this Device device)
        {
            switch (device)
            {
                default:
                    return false;
                case Device.B:
                case Device.M:
                case Device.SB_Special_M:
                case Device.L:
                case Device.V:
                    return true;
            }
        }

        public static bool IsDecimalAddress(this Device device)
        {
            //TODO: 정확한 조사 필요
            switch (device)
            {
                default:
                    return false;
                case Device.M:
                    return true;
            }
        }

    }
}