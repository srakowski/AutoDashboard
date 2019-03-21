using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoDashboard.UniversalApp.Models;

namespace AutoDashboard.UniversalApp.AutoReaders
{
    class SimulatedAutoReader : IAutoReader
    {
        private bool _shutdown;
        private double _rpm;

        public SimulatedAutoReader(double rpm = 0)
        {
            _rpm = rpm;
        }

        public Task<Rpm> GetRpm()
        {
            return Task.FromResult(new Rpm((int)_rpm));
        }

        // 0 -> 9 scalar x 1000 == targetRpm
        public int Pedal { get; set; }

        public Task Start()
        {
            return Task.Factory.StartNew(Run);
        }

        private void Run()
        {
            var start = DateTime.UtcNow;
            while (!_shutdown)
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
            _shutdown = true;
        }
    }
}
