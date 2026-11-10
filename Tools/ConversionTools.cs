using System.ComponentModel;
using ModelContextProtocol.Server;

/// <summary>
/// Unit conversion tools.
/// </summary>
internal class ConversionTools
{
    [McpServerTool]
    [Description("Converts a temperature from Celsius to Fahrenheit.")]
    public double CelsiusToFahrenheit(
        [Description("Temperature in Celsius")] double celsius)
        => (celsius * 9 / 5) + 32;

    [McpServerTool]
    [Description("Converts a temperature from Fahrenheit to Celsius.")]
    public double FahrenheitToCelsius(
        [Description("Temperature in Fahrenheit")] double fahrenheit)
        => (fahrenheit - 32) * 5 / 9;

    [McpServerTool]
    [Description("Converts a distance from kilometers to miles.")]
    public double KilometersToMiles(
        [Description("Distance in kilometers")] double kilometers)
        => kilometers * 0.621371;

    [McpServerTool]
    [Description("Converts a distance from miles to kilometers.")]
    public double MilesToKilometers(
        [Description("Distance in miles")] double miles)
        => miles * 1.60934;

    [McpServerTool]
    [Description("Converts a weight from kilograms to pounds.")]
    public double KilogramsToPounds(
        [Description("Weight in kilograms")] double kilograms)
        => kilograms * 2.20462;

    [McpServerTool]
    [Description("Converts a weight from pounds to kilograms.")]
    public double PoundsToKilograms(
        [Description("Weight in pounds")] double pounds)
        => pounds * 0.453592;
}
