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

        private readonly Dictionary<Device, IDeviceRepo> _Devices;

        public IReadOnlyDictionary<Device, IDeviceRepo> Devices => _Devices;

        public DeviceRepoManager()
        {
            _Devices = new Dictionary<Device, IDeviceRepo>();
        }

        public bool AddDeviceBlock(Device device, int length)
        {
            if (_Devices.ContainsKey(device))
                return false;

            _Devices.Add(device, DeviceRepoFactory.MakeDeviceRepo(device, length));

            return true;
        }

        public bool RemoveDeviceBlock(Device device)
        {
            if (!_Devices.ContainsKey(device))
                return false;
                
            return _Devices.Remove(device);
        }

        public ErrorCode ReadDeviceBlock(Device device, int address, int length, ref short[] readValues)
        {
            if (!_Devices.TryGetValue(device, out IDeviceRepo deviceRepo))
                return ErrorCode.DeviceIsNotExist;

            return deviceRepo.ReadDeviceBlock(device, address, length, ref readValues);
        }

        public ErrorCode WriteDeviceBlock(Device device, int address, int length, ref short[] writeValues)
        {
            if (!_Devices.TryGetValue(device, out IDeviceRepo deviceRepo))
                return ErrorCode.DeviceIsNotExist;

            return deviceRepo.WriteDeviceBlock(device, address, length, ref writeValues);
        }

        public ErrorCode WriteBit(Device device, int address, bool value)
        {
            if (!_Devices.TryGetValue(device, out IDeviceRepo deviceRepo))
                return ErrorCode.DeviceIsNotExist;

            return deviceRepo.WriteBit(device, address, value);
        }

    }

    
}