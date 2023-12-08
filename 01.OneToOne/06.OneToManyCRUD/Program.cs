
// Edit
using (ApplicationContext db = new ApplicationContext())
{
    // İstifadəçinin adının dəyişdirilməsi
    User? user1 = db.Users.FirstOrDefault(p => p.Name == "Tom");
    if (user1 != null)
    {
        user1.Name = "Tomek";
        db.SaveChanges();
    }
    // Şirkətin adının dəyişdirilməsi
    Company? comp = db.Companies.FirstOrDefault(p => p.Name == "Google");
    if (comp != null)
    {
        comp.Name = "Alphabet";
        db.SaveChanges();
    }

    // Əməkdaşın şirkətinin dəyişdirilməsi
    User? user2 = db.Users.FirstOrDefault(p => p.Name == "Bob");
    if (user2 != null && comp != null)
    {
        user2.Company = comp;
        db.SaveChanges();
    }
}

// Delete

using (ApplicationContext db = new ApplicationContext())
{
    User? user = db.Users.FirstOrDefault(u => u.Name == "Bob");
    if (user != null)
    {
        db.Users.Remove(user);
        db.SaveChanges();
    }

    Company? comp = db.Companies.FirstOrDefault();
    if (comp != null)
    {
        db.Companies.Remove(comp);
        db.SaveChanges();
    }
}

Console.WriteLine("\nDone!");