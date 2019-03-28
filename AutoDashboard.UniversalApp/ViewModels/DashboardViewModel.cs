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
        private readonly IAutoReader _reader;

        public DashboardViewModel(IAutoReader reader)
        {
            _reader = reader;
        }

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
                Rpm = (await _reader.Get<Rpm>()).Value;
            }
            catch (Exception ex)
            {
                // intentionally ignore for now
            }
        }
    }
}
