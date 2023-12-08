using Config;
using Microsoft.EntityFrameworkCore;

public class User
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }

    public UserProfile? Profile { get; set; }
}

public class UserProfile
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public int Age { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbHelper.ConnectionStr);
    }
}