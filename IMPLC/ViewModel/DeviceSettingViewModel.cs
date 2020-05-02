﻿using IMPLC.Core;
using IMPLC.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace IMPLC
{
    public class DeviceSettingViewModel : ViewModelBase
    {
        private DeviceRepoManager _DeviceRepo = DeviceRepoManager.Instance;

        public IEnumerable<eDevice> Devices
        {
            get => new List<eDevice>
            {
                eDevice.B,
                eDevice.W
            };
        }

        public eDevice SelectedDevice { get; set; }

        public short Length { get; set; }

        public ObservableCollection<DeviceBlockViewModel> DeviceBlocks { get; private set; }

        public DeviceBlockViewModel[] SelectedDeviceBlocks { get; set; }

        public ICommand AddCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    if (Length < 0)
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
                    if (SelectedDeviceBlocks == null)
                        return;

                    foreach (var selectedDeviceBlock in SelectedDeviceBlocks)
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
            DeviceBlocks = new ObservableCollection<DeviceBlockViewModel>();
            SelectedDevice = Devices.FirstOrDefault();
        }


        private void OnWarningOccured(string message)
        {
            WarningOccured?.Invoke(message);
        }




    }
}