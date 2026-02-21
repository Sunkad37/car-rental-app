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

    public Task<int> CreateUser(User user)
    {
        try
        {
            var userCreated = context.Users.Add(user);
            context.SaveChanges();
            return Task.FromResult(userCreated.Entity.Id);
        }
        catch (Exception ex)
        {
            return Task.FromResult<int>(-1);
        }
    }

    public Task<bool> CheckIfUserExists(string email)
    {
        var userExists = context.Users.Any(x => x.Email == email);
        return Task.FromResult(userExists);
    }
}