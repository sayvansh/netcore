using System;
using System.Collections.Generic;

namespace congestion.calculator;

public class CalenderRule
{
    public Guid Id { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public List<int> Days { get; set; }
}