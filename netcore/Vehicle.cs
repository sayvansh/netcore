using System;

namespace congestion.calculator
{
    public abstract class Vehicle
    {
        public abstract Guid Id { get; set; }
        
        public abstract string VehicleType { get; set; }

        public abstract bool IsTaxFree { get; set; }
    }
}