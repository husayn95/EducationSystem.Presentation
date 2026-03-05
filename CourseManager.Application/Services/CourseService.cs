using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;

namespace CourseManager.Application.Services;

//Här finns logiken som använder repository
public class CourseService
{
    private readonly ICourseRepository _repository;

    //Repository sprutas in via dependency injection
    public CourseService(ICourseRepository repository)
    {
        _repository = repository;
    }

    //hämtar alla kurser
    public List<Course> GetCourses()
    {
        return _repository.GetAll();
    }

    //gör en ny kurs
    public Course CreateCourse(Course course)
    {
        return _repository.Add(course);
    }

    //uppdaterar en kurs
    public Course UpdateCourse(int id, Course course)
    {
        return _repository.Update(id, course);
    }

    //tar bort en kurs
    public void DeleteCourse(int id)
    {
        _repository.Delete(id);
    }
}