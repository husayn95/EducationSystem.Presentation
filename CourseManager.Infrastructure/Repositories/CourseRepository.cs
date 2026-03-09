using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Data;

namespace CourseManager.Infrastructure.Repositories;

/*
 Repository ansvarar för all databasaccess
 för Course-entiteten.
*/
public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    // Hämtar alla kurser
    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }

    // Hämtar en kurs baserat på id
    public Course GetById(int id)
    {
        return _context.Courses.FirstOrDefault(c => c.Id == id);
    }

    // Lägger till en ny kurs
    public Course Add(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();

        return course;
    }

    // Uppdaterar en kurs
    public Course Update(Course course)
    {
        _context.Courses.Update(course);
        _context.SaveChanges();

        return course;
    }

    // Tar bort en kurs
    public void Delete(int id)
    {
        var course = _context.Courses.FirstOrDefault(c => c.Id == id);

        if (course != null)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}
