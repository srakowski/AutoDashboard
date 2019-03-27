namespace AutoDashboard.UniversalApp.Models
{
    public class FuelLevel : IAutoReading
    {
        public FuelLevel(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}