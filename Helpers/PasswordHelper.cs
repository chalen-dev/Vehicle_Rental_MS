using System.Security.Cryptography;

namespace VRMS.Helpers;

public static class PasswordHelper
{
    private const int SaltSize = 16;       // 128-bit
    private const int KeySize = 32;        // 256-bit
    private const int Iterations = 100_000;
    private const char Separator = ':';

    // -------------------------------------------------
    // HASH
    // -------------------------------------------------

    public static string Hash(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Password cannot be empty.", nameof(plainPassword));

        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        using var pbkdf2 = new Rfc2898DeriveBytes(
            plainPassword,
            salt,
            Iterations,
            HashAlgorithmName.SHA256
        );

        var hash = pbkdf2.GetBytes(KeySize);

        // Format: iterations:salt:hash
        return string.Join(
            Separator,
            Iterations,
            Convert.ToBase64String(salt),
            Convert.ToBase64String(hash)
        );
    }

    // -------------------------------------------------
    // VERIFY
    // -------------------------------------------------

    public static bool Verify(string plainPassword, string storedHash)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            return false;

        if (string.IsNullOrWhiteSpace(storedHash))
            return false;

        var parts = storedHash.Split(Separator);
        if (parts.Length != 3)
            return false;

        if (!int.TryParse(parts[0], out var iterations))
            return false;

        var salt = Convert.FromBase64String(parts[1]);
        var expectedHash = Convert.FromBase64String(parts[2]);

        using var pbkdf2 = new Rfc2898DeriveBytes(
            plainPassword,
            salt,
            iterations,
            HashAlgorithmName.SHA256
        );

        var actualHash = pbkdf2.GetBytes(expectedHash.Length);

        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }
}
