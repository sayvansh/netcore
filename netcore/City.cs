using System;
using System.Collections.Generic;

namespace congestion.calculator
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public List<Rule> Rules { get; set; }

        public List<CalenderRule> CalenderRules { get; set; }
    }
}