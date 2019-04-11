using AutoDashboard.UniversalApp.Models.AutoReadings;
using AutoDashboard.UniversalApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.UnitTests.ViewModels
{
    [TestClass]
    public class DashboardViewModelTests
    {
        [TestMethod]
        public async Task UpdatesTheRpmsFromReader()
        {
            var subject = new DashboardViewModel(new MockCarReader
            {
                RpmResult = new Rpm(23)
            });

            await subject.Update();

            var result = subject.Rpm;

            Assert.AreEqual(23, result);
        }

        //[TestMethod]
        //public async Task UpdateSpeedFromReaderInKph()
        //{
        //    var subject = new DashboardViewModel(new MockCarReader
        //    {
        //        SpeedResult = new Models.Speed(20)
        //    });

        //    await subject.Update();
        //    subject.ImperialUnits = false;

        //    var result = subject.Speed;

        //    Assert.AreEqual(20, result);
        //}

        //[TestMethod]
        //public async Task WhenImperialUnitsOn_UpdatesSpeedFromReaderInMph()
        //{
        //    var subject = new DashboardViewModel(new MockCarReader
        //    {
        //        SpeedResult = new Models.Speed(20)
        //    });

        //    await subject.Update();
        //    subject.ImperialUnits = true;

        //    var result = subject.Speed;

        //    Assert.AreEqual(12.4274, result);
        //}
    }
}
