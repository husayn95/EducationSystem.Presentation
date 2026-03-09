using CourseManager.Domain.Entities;
namespace CourseManager.Domain.Interfaces;

/*
 Interface för repository som hanterar databasoperationer
 för Course-entiteten.
*/
public interface ICourseRepository
{
    // Hämtar alla kurser
    List<Course> GetAll();

    // Hämtar en specifik kurs baserat på id
    Course GetById(int id);

    // Lägger till en ny kurs
    Course Add(Course course);

    // Uppdaterar en kurs
    Course Update(Course course);

    // Tar bort en kurs
    void Delete(int id);
}