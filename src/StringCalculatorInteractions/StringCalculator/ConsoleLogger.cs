using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator;

public class ConsoleLogger : ILogCalculationResults
{
    public void Write(string result)
    {
        Console.Write($"At {DateTimeOffset.UtcNow} this result was calculated: {result}); // writes to stdio
    }
}
