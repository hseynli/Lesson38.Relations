using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // Adding models
    Student tom = new Student { Name = "Tom" };
    Student alice = new Student { Name = "Alice" };
    Student bob = new Student { Name = "Bob" };
    db.Students.AddRange(tom, alice, bob);

    Course algorithms = new Course { Name = "Algorithms" };
    Course basics = new Course { Name = "Programming" };
    db.Courses.AddRange(algorithms, basics);

    // Adding courses to students
    tom.Courses.Add(algorithms);
    tom.Courses.Add(basics);
    alice.Courses.Add(algorithms);
    bob.Courses.Add(basics);

    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    var courses = db.Courses.Include(c => c.Students).ToList();
    // Bütün kursları ekrana çıxarırıq
    foreach (var c in courses)
    {
        Console.WriteLine($"Course: {c.Name}");
        // Bu kurs üçün bütün tələbələri ekrana çıxarırıq
        foreach (Student s in c.Students)
            Console.WriteLine($"Name: {s.Name}");
        Console.WriteLine("-------------------");
    }
}