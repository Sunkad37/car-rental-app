using CarRental.Domain.Entities;

namespace CarRental.Infrastructure.Repository;

/// <summary>
/// Get User By User Id
/// </summary>
public interface IUserRepository
{
    Task<User> GetUserById(int userId);
}