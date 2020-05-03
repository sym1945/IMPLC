using System.Windows.Controls;

namespace IMPLC
{
    /// <summary>
    /// DeviceSetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeviceSetting : UserControl
    {
        public DeviceSetting()
        {
            InitializeComponent();
            DataContext = new DeviceSettingViewModel();
        }
    }
}
