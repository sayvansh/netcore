using System;

namespace congestion.calculator
{
    public class Rule
    {
        public Guid Id { get; set; }
        
        public TimeOnly From { get; set; }

        public TimeOnly To { get; set; }

        public int Amount { get; set; }
    }
}