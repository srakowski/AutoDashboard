﻿namespace AutoDashboard.UniversalApp.Models
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
