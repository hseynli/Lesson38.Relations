using Config;
using Microsoft.EntityFrameworkCore;

public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<User> Users { get; set; } = new(); // Şirkətin əməkdaşları
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int CompanyId { get; set; }
    public Company? Company { get; set; }  // İstifadəçinin şirkəti
}

public class ApplicationContext : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbHelper.ConnectionStr);
    }
}