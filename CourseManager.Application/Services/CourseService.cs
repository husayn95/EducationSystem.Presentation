using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
namespace CourseManager.Application.Services;

/*
Service-lagret innehåller affärslogik mellan API och repository.
*/

public class CourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(ICourseRepository repository)
    {
        _repository = repository;
    }

    // Hämtar alla kurser
    public List<Course> GetCourses()
    {
        return _repository.GetAll();
    }

    // Skapar en ny kurs
    public Course CreateCourse(Course course)
    {
        if (string.IsNullOrWhiteSpace(course.Title))
            throw new ArgumentException("Kursnamn får inte vara tomt");

        // Skapar kursen
        var createdCourse = _repository.Add(course);

        // Om kursen har ett kurstillfälle kopplat
        if (course.CourseInstances != null && course.CourseInstances.Any())
        {
            foreach (var instance in course.CourseInstances)
            {
                instance.CourseId = createdCourse.Id;
            }
        }

        return createdCourse;
    }

    // Uppdaterar kurs
    public Course UpdateCourse(int id, Course updatedCourse)
    {
        var existingCourse = _repository.GetById(id);

        if (existingCourse == null)
            return null;

        existingCourse.Title = updatedCourse.Title;

        return _repository.Update(existingCourse);
    }

    // Tar bort kurs
    public bool DeleteCourse(int id)
    {
        var course = _repository.GetById(id);

        if (course == null)
            return false;

        _repository.Delete(id);

        return true;
    }
}