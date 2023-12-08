using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    // AsNoTracking() dəyişikliklər bazaya oturmayacaq
    var user = db.Users.AsNoTracking().FirstOrDefault();
    if (user != null)
    {
        user.Age = 22;
        db.SaveChanges();
    }

    var users = db.Users.AsNoTracking().ToList();
    foreach (var u in users)
        Console.WriteLine($"{u.Name} ({u.Age})");
}