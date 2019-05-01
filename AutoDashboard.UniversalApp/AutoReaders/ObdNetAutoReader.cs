using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoDashboard.UniversalApp.Models;
using AutoDashboard.UniversalApp.Models.AutoReadings;
using OBD.NET.Common.Devices;
using OBD.NET.Common.OBDData;
using OBD.NET.Communication;

namespace AutoDashboard.UniversalApp.AutoReaders
{
    class ObdNetAutoReader : IAutoReader, IDisposable
    {
        private BluetoothSerialConnection _connection;
        private ELM327 _dev;
        private bool _isRunning = false;

        private int _rpmValue;
        private int _engineOilTemp;

        public async Task Initialize()
        {
            if (_isRunning) return;

            _connection = new BluetoothSerialConnection("SPP");
            _dev = new ELM327(_connection);
            await _dev.InitializeAsync();
            _isRunning = true;
        }

        public void Dispose()
        {
            _isRunning = false;
            _dev?.Dispose();
            _dev = null;
            _connection?.Dispose();
            _connection = null;
        }

        public async Task Update()
        {
            if (!_isRunning)
                return;

            var data = await _dev.RequestDataAsync<EngineRPM>();
            if (data != null)
            {
                _rpmValue = data.Rpm;
            }

            var oilTemp = await _dev.RequestDataAsync<EngineFuelRate>();
            if (oilTemp != null)
            {
                Debug.WriteLine(oilTemp.ToString());
            }
        }

        public Task<T> Get<T>() where T : IAutoReading
        {
            if (!_isRunning)
            {
                return null;
            }

            if (typeof(T) == typeof(Rpm))
            {
                return Task.FromResult(new Rpm(_rpmValue)) as Task<T>;
            }

            return null;
        }
    }
}
