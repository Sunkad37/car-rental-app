namespace CarRental.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
    public string ProfileImage { get; set; } = null!;
}