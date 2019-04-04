using AutoDashboard.UniversalApp.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _rpms;

        public DashboardViewModel(IAutoReader reader)
        {
            AutoReader = reader;
        }

        public IAutoReader AutoReader { get; set; }

        public int Rpm
        {
            get => _rpms;
            set
            {
                _rpms = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rpm)));
            }
        }

        public async Task Update()
        {
            try
            {
                Rpm = (await AutoReader.Get<Rpm>())?.Value ?? 0;
            }
            catch (Exception ex)
            {
                // intentionally ignore for now
            }
        }
    }
}
