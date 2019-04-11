using System.Threading.Tasks;
using AutoDashboard.UniversalApp.Models;
using AutoDashboard.UniversalApp.Models.AutoReadings;

namespace AutoDashboard.UniversalApp.UnitTests
{
    public class MockCarReader : IAutoReader
    {
        public Rpm RpmResult { get; set; }

        public Task<T> Get<T>() where T : IAutoReading
        {
            if (typeof(T) == typeof(Rpm))
            {
                return Task.FromResult(RpmResult) as Task<T>;
            }

            throw new System.Exception($"unrecognized type {typeof(T).Name}");
        }
    }
}
