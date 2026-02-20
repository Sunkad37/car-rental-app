using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repository;

public class UserRepository(AppDbContext context) : IUserRepository
{
    // Get User By I'd
    public async Task<User> GetUserById(int userId)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
        return user!;
    }
}