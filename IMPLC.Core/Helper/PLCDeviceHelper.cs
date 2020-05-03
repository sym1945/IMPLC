namespace IMPLC.Core
{
    public static class PLCDeviceHelper
    {
        public static bool IsBitDevice(this eDevice device)
        {
            switch (device)
            {
                default:
                    return false;
                case eDevice.B:
                case eDevice.M:
                case eDevice.SB_Special_M:
                case eDevice.L:
                case eDevice.V:
                    return true;
            }
        }

        public static bool IsDecimalAddress(this eDevice device)
        {
            //TODO: 정확한 조사 필요
            switch (device)
            {
                default:
                    return false;
                case eDevice.M:
                    return true;
            }
        }

    }
}