namespace AutoDashboard.UniversalApp.Models.AutoReadings
{
    public class Rpm : IAutoReading
    {
        public Rpm(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
