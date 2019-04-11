using AutoDashboard.UniversalApp.Models;
using AutoDashboard.UniversalApp.Models.AutoReadings;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.AutoReaders
{
    public class SimulatedAutoReader : IAutoReader
    {
        private static HttpClient _client = new HttpClient();

        private string _vin;
        private bool _isRunning;
        private double _rpm;

        public SimulatedAutoReader(double rpm = 0)
        {
            _rpm = rpm;
        }

        public Task<T> Get<T>() where T : IAutoReading
        {
            if (!_isRunning)
            {
                throw new InvalidOperationException("you must call Start before requesting");
            }

            if (typeof(T) == typeof(Rpm))
            {
                return Task.FromResult(new Rpm((int)_rpm)) as Task<T>;
            }
            else if (typeof(T) == typeof(VinNumber))
            {
                return Task.FromResult(new VinNumber(_vin)) as Task<T>;
            }

            return Task.FromResult(new FuelLevel(0)) as Task<T>;
        }

        // 0 -> 9 scalar x 1000 == targetRpm
        public int Pedal { get; set; }

        public async Task Start()
        {
            _isRunning = true;

            var response = await _client.GetAsync("http://randomvin.com/getvin.php?type=real");
            _vin = response.IsSuccessStatusCode
                ? (await response.Content.ReadAsStringAsync())
                : "5UXWX7C5*BA";

            await Task.Factory.StartNew(Run);
        }

        private void Run()
        {
            var start = DateTime.UtcNow;
            while (_isRunning)
            {
                var now = DateTime.UtcNow;
                var delta = now - start;
                start = now;

                var targetRpm = Pedal * 1000;
                if (_rpm < targetRpm)
                {
                    _rpm += delta.TotalMilliseconds * 1.2;
                }
                else if (_rpm > targetRpm)
                {
                    _rpm -= delta.TotalMilliseconds * 1.2;
                }

                if (_rpm < 0) _rpm = 0;

                //Debug.WriteLine(_rpm);
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
