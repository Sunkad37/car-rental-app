namespace CarRental.Application.Common.Interfaces;

public interface IPasswordService
{
    (string hash, string salt) CreatePasswordHash(string password);
    bool VerifyPassword(string password, string storedHash, string storedSalt);
}