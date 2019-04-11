namespace AutoDashboard.UniversalApp.Models.AutoReadings
{
    public class VinNumber : IAutoReading
    {
        public VinNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
