using System;
using System.Linq;
using System.Threading.Tasks;

namespace congestion.calculator;

public class CongestionTaxCalculator : ICongestionTaxCalculator
{
    public async Task<decimal> CalculateCongestionTaxAsync(Vehicle vehicle, City city, DateTime[] dateTimes)
    {
        if (vehicle.IsTaxFree) return 0;
        var appliedRules = (from dateTime
                    in dateTimes
                where !IsFreeDate(city, dateTime)
                select city.Rules.FirstOrDefault(rule => rule.From > TimeOnly.FromDateTime(dateTime) &&
                                                         rule.To < TimeOnly.FromDateTime(dateTime)))
            .ToList();
        var taxSum = appliedRules.Sum(rule => rule.Amount);
        return taxSum;
    }

    private static bool IsFreeDate(City city, DateTime dateTime)
    {
        return city.CalenderRules.Any(rule => rule.Year == dateTime.Year && rule.Month == dateTime.Month && rule.Days.Any(i => i == dateTime.Day));
    }
}