using IMPLC.Core;

namespace IMPLC
{
    public class DeviceBlockViewModel : ViewModelBase
    {
        public eDevice Device { get; private set; }

        public short Length { get; private set; }

        public DeviceBlockViewModel(eDevice device, short length)
        {
            Device = device;
            Length = length;
        }

    }
}