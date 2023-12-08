
// Edit
using (ApplicationContext db = new ApplicationContext())
{
    User? user = db.Users.FirstOrDefault();
    // User-in birinci obyektini əldə edirik
    if (user != null)
    {
        user.Password = "dsfvbggg";
        db.SaveChanges();
    }

    // login2 adlı loqini olan birini UserProfile obyektini əldə edirik
    UserProfile? profile = db.UserProfiles.FirstOrDefault(p => p.User.Login == "login2");
    if (profile != null)
    {
        profile.Name = "Alice II";
        db.SaveChanges();
    }
}

// Delete
using (ApplicationContext db = new ApplicationContext())
{
    // Birinci tapılanı silirik
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        db.Users.Remove(user);
        db.SaveChanges();
    }

    // login2 adlı loqin olan UserProfile-i silirik
    UserProfile? profile = db.UserProfiles.FirstOrDefault(p => p.User.Login == "login2");
    if (profile != null)
    {
        db.UserProfiles.Remove(profile);
        db.SaveChanges();
    }
}

Console.WriteLine("\nDone!");