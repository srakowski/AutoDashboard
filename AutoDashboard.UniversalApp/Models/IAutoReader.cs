using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.Models
{
    public interface IAutoReader
    {
        Task<T> Get<T>() where T : IAutoReading;
    }
}
