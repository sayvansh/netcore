using System;

namespace congestion.calculator
{
    public class Motorbike : Vehicle
    {
        public override Guid Id { get; set; }
        public override string VehicleType { get; set; }
        
        public override bool IsTaxFree { get; set; }
    }
}