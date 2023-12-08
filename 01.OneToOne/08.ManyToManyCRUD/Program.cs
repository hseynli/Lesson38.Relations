using Microsoft.EntityFrameworkCore;

// Edit and Delete
using (ApplicationContext db = new ApplicationContext())
{
    Student? alice = db.Students.Include(s => s.Courses).FirstOrDefault(s => s.Name == "Alice");
    Course? algorithms = db.Courses.FirstOrDefault(c => c.Name == "Algorithms");
    Course? basics = db.Courses.FirstOrDefault(c => c.Name == "Programming");
    if (alice != null && algorithms != null && basics != null)
    {
        // Deleting course for student
        alice.Courses.Remove(algorithms);
        // Adding the new course for student
        alice.Courses.Add(basics);
        db.SaveChanges();
    }
}

Console.WriteLine("\nDone!");