namespace AutoDashboard.UniversalApp.Models.AutoReadings
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