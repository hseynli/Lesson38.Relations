using Config;
using Microsoft.EntityFrameworkCore;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Student> Students { get; set; } = new();
}
public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Course> Courses { get; set; } = new();
}
public class ApplicationContext : DbContext
{
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbHelper.ConnectionStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(j => j.ToTable("Enrollments"));
    }
}