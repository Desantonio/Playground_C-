// BinomialOptionsPricing.cs
using System;

public class BinomialOptionsPricing
{
    public static double CalculateOptionPrice(double spotPrice, double strikePrice, double volatility, double riskFreeRate,
        int timeSteps, double timeToMaturity, bool isCallOption)
    {
        double deltaT = timeToMaturity / timeSteps;
        double upFactor = Math.Exp(volatility * Math.Sqrt(deltaT));
        double downFactor = 1.0 / upFactor;
        double probabilityUp = (Math.Exp(riskFreeRate * deltaT) - downFactor) / (upFactor - downFactor);

        // Initialize the option values at maturity
        double[] optionValues = new double[timeSteps + 1];
        for (int i = 0; i <= timeSteps; i++)
        {
            double spotPriceAtMaturity = spotPrice * Math.Pow(upFactor, i) * Math.Pow(downFactor, timeSteps - i);
            optionValues[i] = Math.Max(0, (isCallOption ? 1 : -1) * (spotPriceAtMaturity - strikePrice));
        }

        // Move backward through the tree to calculate option values at earlier time steps
        for (int step = timeSteps - 1; step >= 0; step--)
        {
            for (int i = 0; i <= step; i++)
            {
                optionValues[i] = Math.Exp(-riskFreeRate * deltaT) * (probabilityUp * optionValues[i + 1] + (1 - probabilityUp) * optionValues[i]);
            }
        }

        return optionValues[0];
    }
}
