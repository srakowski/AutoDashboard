using AutoDashboard.UniversalApp.AutoReaders;
using AutoDashboard.UniversalApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AutoDashboard.UniversalApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SimulatedAutoReader _autoReader;

        public MainPage()
        {
            this.InitializeComponent();
            _autoReader = new SimulatedAutoReader();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                var rpm = await _autoReader.Get<Rpm>();
                rpmTextBlock.Text = rpm.Value.ToString();
                radialGaugeControl.Value = rpm.Value;
                await Task.Delay(100);
            }
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            await _autoReader.Start();
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            _autoReader.Pedal = (int)e.NewValue;
        }
    }
}
