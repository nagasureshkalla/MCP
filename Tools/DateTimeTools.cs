using System.ComponentModel;
using System.Globalization;
using ModelContextProtocol.Server;

/// <summary>
/// Date and time calculation tools.
/// </summary>
internal class DateTimeTools
{
    [McpServerTool]
    [Description("Gets the current date and time in UTC, in ISO 8601 format.")]
    public string GetCurrentUtcTime()
        => DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture);

    [McpServerTool]
    [Description("Calculates the number of whole days between two dates (yyyy-MM-dd).")]
    public int DaysBetweenDates(
        [Description("Start date in yyyy-MM-dd format")] string startDate,
        [Description("End date in yyyy-MM-dd format")] string endDate)
    {
        var start = DateTime.Parse(startDate, CultureInfo.InvariantCulture);
        var end = DateTime.Parse(endDate, CultureInfo.InvariantCulture);
        return (end - start).Days;
    }

    [McpServerTool]
    [Description("Adds a number of days to a date and returns the resulting date (yyyy-MM-dd).")]
    public string AddDaysToDate(
        [Description("Starting date in yyyy-MM-dd format")] string date,
        [Description("Number of days to add (can be negative)")] int days)
        => DateTime.Parse(date, CultureInfo.InvariantCulture).AddDays(days).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

    [McpServerTool]
    [Description("Determines whether a given year is a leap year.")]
    public bool IsLeapYear(
        [Description("Year to check")] int year)
        => DateTime.IsLeapYear(year);

    [McpServerTool]
    [Description("Gets the day of the week for a given date (yyyy-MM-dd).")]
    public string GetDayOfWeek(
        [Description("Date in yyyy-MM-dd format")] string date)
        => DateTime.Parse(date, CultureInfo.InvariantCulture).DayOfWeek.ToString();
}
