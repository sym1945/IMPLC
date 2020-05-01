using IMPLC.Core;
using IMPLC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMPLC
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        IPLCService plcService = PLCServiceProvider.GetService(PLCServiceType.IPC);

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var DeviceRepo = DeviceRepoManager.Instance;
            DeviceRepo.AddDeviceBlock(eDevice.W, 10);    
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            plcService.Start("localhost:9090");
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            plcService.Stop();
        }

    }
}
