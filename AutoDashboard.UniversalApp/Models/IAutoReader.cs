using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.Models
{
    interface IAutoReader
    {
        Task<Rpm> GetRpm();
    }
}
