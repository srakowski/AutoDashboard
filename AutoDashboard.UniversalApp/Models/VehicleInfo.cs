namespace AutoDashboard.UniversalApp.Models
{
    public class VehicleInfo
    {
        public VehicleInfo(string make, string model, string modelYear)
        {
            Make = make;
            Model = model;
            ModelYear = modelYear;
        }
        public string Make { get; }
        public string Model { get; }
        public string ModelYear { get; }
    }
}