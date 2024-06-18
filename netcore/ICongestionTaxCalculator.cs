using System;
using System.Threading.Tasks;

namespace congestion.calculator;

public interface ICongestionTaxCalculator
{
    public Task<decimal> CalculateCongestionTaxAsync(Vehicle vehicle, City city, DateTime[] dateTimes);
}