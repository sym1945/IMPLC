﻿using IMPLC.Core;

namespace IMPLC
{
    public class DeviceBlockViewModel : ViewModelBase
    {
        public eDevice Device { get; private set; }

        public short Length { get; private set; }

        public string StartAddress => $"{Device}0000";

        public string EndAddress => Device.IsDecimalAddress() ? $"{Device}{Length}" : $"{Device}{Length - 1:X4}";

        public DeviceBlockViewModel(eDevice device, short length)
        {
            Device = device;
            Length = length;
        }

    }
}