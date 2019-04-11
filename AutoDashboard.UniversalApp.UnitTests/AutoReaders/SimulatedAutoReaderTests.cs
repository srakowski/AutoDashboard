using AutoDashboard.UniversalApp.AutoReaders;
using AutoDashboard.UniversalApp.Models;
using AutoDashboard.UniversalApp.Models.AutoReadings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.UnitTests.AutoReaders
{
    [TestClass]
    public class SimulatedAutoReaderTests
    {
        private SimulatedAutoReader reader;

        [TestInitialize]
        public void Initialize()
        {
            reader = new SimulatedAutoReader();
        }

        [TestMethod]
        public async Task GivenTheSimulatorHasntStarted_WhenGetIsCalled_ThenThrowsAnException()
        {
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => 
            {
                await reader.Get<FuelLevel>();
            });
        }

        [TestMethod]
        public async Task GetFuelLevel()
        {
            reader.Start();
            var fuelLevel = await reader.Get<FuelLevel>();
            reader.Stop();
            Assert.IsNotNull(fuelLevel);
        }

        [TestMethod]
        public async Task GetRpm()
        {
            reader.Start();
            var rpms = await reader.Get<Rpm>();
            reader.Stop();
            Assert.IsNotNull(rpms);
        }
    }
}
