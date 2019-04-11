using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.Models
{
    public interface IVehicleInfoService
    {
        Task<VehicleInfo> GetVehicleInfoByVin(string vinNumber);
    }
}
