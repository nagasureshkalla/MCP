using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using ModelContextProtocol.Server;

/// <summary>
/// Hashing and identifier generation tools.
/// </summary>
internal class HashTools
{
    [McpServerTool]
    [Description("Computes the MD5 hash of a string, returned as a lowercase hex string.")]
    public string ComputeMd5Hash(
        [Description("Text to hash")] string text)
        => Convert.ToHexStringLower(MD5.HashData(Encoding.UTF8.GetBytes(text)));

    [McpServerTool]
    [Description("Computes the SHA-256 hash of a string, returned as a lowercase hex string.")]
    public string ComputeSha256Hash(
        [Description("Text to hash")] string text)
        => Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text)));

    [McpServerTool]
    [Description("Generates a new random GUID/UUID.")]
    public string GenerateGuid()
        => Guid.NewGuid().ToString();
}
