using IMPLC.Core;
using IMPLC.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace IMPLC
{
    public class DeviceSettingViewModel : ViewModelBase
    {
        private const int MAX_DEVICE_LENGTH = 0x1FFFF;

        private readonly DeviceRepoManager _DeviceRepo = DeviceRepoManager.Instance;

        private int _LastAddress = MAX_DEVICE_LENGTH;


        public IEnumerable<Device> Devices
        {
            get => new List<Device>
            {
                Device.B,
                Device.W
            };
        }

        public Device SelectedDevice { get; set; }

        public int LastAddress
        {
            get => _LastAddress;
            set
            {
                if (_LastAddress == value)
                    return;
                if (value > MAX_DEVICE_LENGTH)
                    _LastAddress = MAX_DEVICE_LENGTH;
                else
                    _LastAddress = value;

                OnPropertyChanged();
            }
        }

        public int Length
        {
            get => _LastAddress + 1;
        }


        public ObservableCollection<DeviceBlockViewModel> DeviceBlocks { get; private set; }

        public ICommand AddCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    if (Length <= 0)
                    {
                        OnWarningOccured(Resources.DEVICE_LENGTH_ERROR);
                        return;
                    }

                    if (_DeviceRepo.AddDeviceBlock(SelectedDevice, Length))
                        DeviceBlocks.Add(new DeviceBlockViewModel(SelectedDevice, Length));
                }
            };
        }

        public ICommand RemoveCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    if (!(param is IList selectedItems))
                        return;

                    foreach (DeviceBlockViewModel selectedDeviceBlock in selectedItems.OfType<DeviceBlockViewModel>().ToList())
                    {
                        if (_DeviceRepo.RemoveDeviceBlock(selectedDeviceBlock.Device))
                            DeviceBlocks.Remove(selectedDeviceBlock);
                    }
                }
            };
        }

        public event Action<string> WarningOccured;


        public DeviceSettingViewModel()
        {
            var managedDeviceBlocks = _DeviceRepo.Devices.Select(d => new DeviceBlockViewModel(d.Key, d.Value.Length));
            DeviceBlocks = new ObservableCollection<DeviceBlockViewModel>(managedDeviceBlocks);
            SelectedDevice = Devices.FirstOrDefault();
        }


        private void OnWarningOccured(string message)
        {
            WarningOccured?.Invoke(message);
        }


    }
}