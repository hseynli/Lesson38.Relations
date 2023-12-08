using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using (ApplicationContext db = new ApplicationContext())
{
    // Bazanı yenidən yaradırıq
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // Modellərin yaradılması və əlavə edilməsi
    Company microsoft = new Company { Name = "Microsoft" };
    Company google = new Company { Name = "Google" };
    db.Companies.AddRange(microsoft, google);

    User tom = new User { Name = "Tom", Company = microsoft };
    User bob = new User { Name = "Bob", Company = microsoft };
    User alice = new User { Name = "Alice", Company = google };
    db.Users.AddRange(tom, bob, alice);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.Include(u => u.Company).ToList();
    foreach (User user in users)
        Console.WriteLine($"{user.Name} - {user.Company?.Name}");

    var companies = db.Companies.Include(c => c.Users).ToList();
    foreach (Company comp in companies)
    {
        Console.WriteLine($"\n Şirkət: {comp.Name}");
        foreach (User user in comp.Users)
        {
            Console.WriteLine($"{user.Name}");
        }
    }
}