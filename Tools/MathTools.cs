using System.ComponentModel;
using ModelContextProtocol.Server;

/// <summary>
/// Basic arithmetic and number-theory tools.
/// </summary>
internal class MathTools
{
    [McpServerTool]
    [Description("Adds two numbers together.")]
    public double Add(
        [Description("First number")] double a,
        [Description("Second number")] double b)
        => a + b;

    [McpServerTool]
    [Description("Subtracts the second number from the first.")]
    public double Subtract(
        [Description("First number")] double a,
        [Description("Second number")] double b)
        => a - b;

    [McpServerTool]
    [Description("Multiplies two numbers together.")]
    public double Multiply(
        [Description("First number")] double a,
        [Description("Second number")] double b)
        => a * b;

    [McpServerTool]
    [Description("Divides the first number by the second.")]
    public double Divide(
        [Description("Numerator")] double a,
        [Description("Denominator")] double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return a / b;
    }

    [McpServerTool]
    [Description("Raises a number to the given power.")]
    public double Power(
        [Description("Base value")] double baseValue,
        [Description("Exponent")] double exponent)
        => Math.Pow(baseValue, exponent);

    [McpServerTool]
    [Description("Calculates the square root of a number.")]
    public double SquareRoot(
        [Description("Value to take the square root of (must be non-negative)")] double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Cannot take the square root of a negative number.");
        }

        return Math.Sqrt(value);
    }

    [McpServerTool]
    [Description("Determines whether a number is a prime number.")]
    public bool IsPrime(
        [Description("Number to check")] long number)
    {
        if (number < 2)
        {
            return false;
        }

        for (long i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    [McpServerTool]
    [Description("Calculates the greatest common divisor of two integers.")]
    public long GreatestCommonDivisor(
        [Description("First integer")] long a,
        [Description("Second integer")] long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }

    [McpServerTool]
    [Description("Calculates the least common multiple of two integers.")]
    public long LeastCommonMultiple(
        [Description("First integer")] long a,
        [Description("Second integer")] long b)
    {
        if (a == 0 || b == 0)
        {
            return 0;
        }

        long gcd = GreatestCommonDivisor(a, b);
        return Math.Abs(a / gcd * b);
    }
}
