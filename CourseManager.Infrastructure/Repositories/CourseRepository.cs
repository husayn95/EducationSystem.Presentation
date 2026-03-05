using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Data;

namespace CourseManager.Infrastructure.Repositories;

//Denna klass sparar och läser data från databasen
public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    //konstruktor som tar emot DbContext via dependency injection
    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    //hämtar alla kurser från databasen
    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }

    //Lägger till en ny kurs i databasen
    public Course Add(Course course)
    {
        _context.Courses.Add(course);

        //Sparar ändringar i databasen
        _context.SaveChanges();

        return course;
    }

    //uppdaterar en befintlig kurs
    public Course Update(int id, Course updated)
    {
        // Hitta kursen i databasen
        var course = _context.Courses.Find(id);

        if (course == null)
            return null;

        // Uppdaterar värden
        course.Title = updated.Title;
        course.Teacher = updated.Teacher;

        _context.SaveChanges();

        return course;
    }

    //Tar bort en kurs från databasen
    public void Delete(int id)
    {
        var course = _context.Courses.Find(id);

        if (course != null)
        {
            _context.Courses.Remove(course);

            _context.SaveChanges();
        }
    }
}
