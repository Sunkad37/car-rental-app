using CarRental.Application.Common.Interfaces;
using System.Security.Cryptography;

namespace CarRental.Application.Common.Services;

public class PasswordService : IPasswordService
{
    private const int SaltSize = 16; // 128 bit
    private const int KeySize = 32;  // 256 bit
    private const int Iterations = 10000;

    [Obsolete("Obsolete")]
    public (string hash, string salt) CreatePasswordHash(string password)
    {
        using var rng = RandomNumberGenerator.Create();

        var saltBytes = new byte[SaltSize];
        rng.GetBytes(saltBytes);

        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            Iterations,
            HashAlgorithmName.SHA256);

        var hashBytes = pbkdf2.GetBytes(KeySize);

        return (
            Convert.ToBase64String(hashBytes),
            Convert.ToBase64String(saltBytes)
        );
    }

    [Obsolete("Obsolete")]
    public bool VerifyPassword(string password, string storedHash, string storedSalt)
    {
        var saltBytes = Convert.FromBase64String(storedSalt);

        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            Iterations,
            HashAlgorithmName.SHA256);

        var computedHash = Convert.ToBase64String(pbkdf2.GetBytes(KeySize));

        return computedHash == storedHash;
    }
}
