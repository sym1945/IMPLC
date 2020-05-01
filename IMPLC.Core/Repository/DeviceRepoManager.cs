using System.Collections.Generic;

namespace IMPLC.Core
{
    public sealed class DeviceRepoManager
    {
        public  static readonly DeviceRepoManager Instance;

        static DeviceRepoManager()
        {
            Instance = new DeviceRepoManager();
        }

        private readonly Dictionary<eDevice, IDeviceRepo> _Devices;

        public DeviceRepoManager()
        {
            _Devices = new Dictionary<eDevice, IDeviceRepo>();
        }

        public void AddDeviceBlock(eDevice device, short length)
        {
            if (!_Devices.ContainsKey(device))
                _Devices.Add(device, DeviceRepoFactory.MakeDeviceRepo(device, length));
        }

        public void RemoveDeviceBlock(eDevice device)
        {
            if (_Devices.ContainsKey(device))
                _Devices.Remove(device);
        }

        public ErrorCode ReadDeviceBlock(eDevice device, short address, short length, out short[] readValues)
        {
            readValues = null;
            if (!_Devices.TryGetValue(device, out IDeviceRepo deviceRepo))
                return ErrorCode.DeviceIsNotExist;

            return deviceRepo.ReadDeviceBlock(device, address, length, out readValues);
        }

        public ErrorCode WriteDeviceBlock(eDevice device, short address, short length, ref short[] writeValues)
        {
            if (!_Devices.TryGetValue(device, out IDeviceRepo deviceRepo))
                return ErrorCode.DeviceIsNotExist;

            return deviceRepo.WriteDeviceBlock(device, address, length, ref writeValues);
        }

        public ErrorCode WriteBit(eDevice device, short address, bool value)
        {
            if (!_Devices.TryGetValue(device, out IDeviceRepo deviceRepo))
                return ErrorCode.DeviceIsNotExist;

            return deviceRepo.WriteBit(device, address, value);
        }

    }



    public class DeviceRepoFactory
    {
        public static bool IsBitDevice(eDevice device)
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

        public static IDeviceRepo MakeDeviceRepo(eDevice device, short length)
        {
            if (IsBitDevice(device))
                return new BitDeviceRepo(length);
            else
                return new WordDeviceRepo(length);
        }
    }
}