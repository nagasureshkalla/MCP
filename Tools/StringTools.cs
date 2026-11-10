using System.ComponentModel;
using System.Globalization;
using ModelContextProtocol.Server;

/// <summary>
/// Text manipulation and inspection tools.
/// </summary>
internal class StringTools
{
    [McpServerTool]
    [Description("Converts text to upper case.")]
    public string ToUpperCase(
        [Description("Text to convert")] string text)
        => text.ToUpperInvariant();

    [McpServerTool]
    [Description("Converts text to lower case.")]
    public string ToLowerCase(
        [Description("Text to convert")] string text)
        => text.ToLowerInvariant();

    [McpServerTool]
    [Description("Converts text to title case (each word capitalized).")]
    public string ToTitleCase(
        [Description("Text to convert")] string text)
        => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text.ToLowerInvariant());

    [McpServerTool]
    [Description("Reverses the characters in a string.")]
    public string ReverseString(
        [Description("Text to reverse")] string text)
        => new string(text.Reverse().ToArray());

    [McpServerTool]
    [Description("Counts the number of words in a string.")]
    public int CountWords(
        [Description("Text to analyze")] string text)
        => text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length;

    [McpServerTool]
    [Description("Counts the number of characters in a string.")]
    public int CountCharacters(
        [Description("Text to analyze")] string text)
        => text.Length;

    [McpServerTool]
    [Description("Checks whether a string is a palindrome (ignoring case and spaces).")]
    public bool IsPalindrome(
        [Description("Text to check")] string text)
    {
        var cleaned = new string(text.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();
        var reversed = new string(cleaned.Reverse().ToArray());
        return cleaned == reversed;
    }

    [McpServerTool]
    [Description("Replaces all occurrences of a substring within a string.")]
    public string ReplaceText(
        [Description("Original text")] string text,
        [Description("Substring to search for")] string oldValue,
        [Description("Replacement substring")] string newValue)
        => text.Replace(oldValue, newValue);

    [McpServerTool]
    [Description("Encodes text as Base64.")]
    public string Base64Encode(
        [Description("Plain text to encode")] string text)
        => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));

    [McpServerTool]
    [Description("Decodes a Base64 string back to plain text.")]
    public string Base64Decode(
        [Description("Base64-encoded text to decode")] string base64Text)
        => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64Text));
}
