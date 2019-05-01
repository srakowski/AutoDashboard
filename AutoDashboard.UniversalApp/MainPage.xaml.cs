using AutoDashboard.UniversalApp.AutoReaders;
using AutoDashboard.UniversalApp.Models;
using AutoDashboard.UniversalApp.ViewModels;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace AutoDashboard.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        //private SimulatedAutoReader _simulator;
        private DashboardViewModel _vm;
        private ObdNetAutoReader _obdReader;

        public MainPage()
        {
            this.InitializeComponent();
            //_simulator = new SimulatedAutoReader();
            _obdReader = new ObdNetAutoReader();

            this.DataContext = _vm = new DashboardViewModel(_obdReader, new Services.NhtsaVehicleInfoService());
            //this.configuration.DataContext = new ConfigurationViewModel();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                await _obdReader.Update();
                await _vm.Update();
                await Task.Delay(100);
            }
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            await _obdReader.Initialize();
            //await _simulator.Start();
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //_simulator.Pedal = (int)e.NewValue;
        }

        //// TODO: remove
        //private async void PingButton_Click(object sender, RoutedEventArgs e)
        //{
        //    pingResponse.Text = "";
        //    pingResponse.Text = await ExternalSimulatorAutoReader.Ping("ping");
        //}

        //private async void SingButton_Click(object sender, RoutedEventArgs e)
        //{
        //    singResponse.Text = "";
        //    singResponse.Text = await ExternalSimulatorAutoReader.Ping("sing");
        //}
    }
}
