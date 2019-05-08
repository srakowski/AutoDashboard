using AutoDashboard.UniversalApp.Models;
using AutoDashboard.UniversalApp.Models.AutoReadings;
using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _rpms;
        private string _vin;
        private VehicleInfo _vehicleInfo;
        private readonly IVehicleInfoService _vehicleInfoService;

        public DashboardViewModel(IAutoReader reader, IVehicleInfoService vehicleInfoService)
        {
            AutoReader = reader;
            _vehicleInfoService = vehicleInfoService;
        }        

        public IAutoReader AutoReader { get; set; }

        public int Rpm
        {
            get => _rpms;
            set => Set(ref _rpms, value);
        }

        public string VinNumber
        {
            get => _vin;
            set
            {
                _vin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VinNumber)));
            }
        }

        public string Make
        {
            get => _vehicleInfo?.Make;
        }

        public string Model
        {
            get => _vehicleInfo?.Model;
        }

        public string ModelYear
        {
            get => _vehicleInfo?.ModelYear;
        }

        public async Task Update()
        {
            try
            {
                Rpm = (await AutoReader.Get<Rpm>())?.Value ?? 0;
                //var vin = (await AutoReader.Get<VinNumber>())?.Value ?? "ERROR";
                //if (vin != VinNumber)
                //{
                //    if (vin == null)
                //    {
                //        _vehicleInfo = null;
                //    }
                //    else
                //    {
                //        _vehicleInfo = await _vehicleInfoService.GetVehicleInfoByVin(vin);
                //    }
                //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Make)));
                //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
                //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModelYear)));
                //}
                //VinNumber = vin;
            }
            catch (Exception ex)
            {
                // intentionally ignore for now
            }
        }
    }
}
