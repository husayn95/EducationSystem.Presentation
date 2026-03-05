using CourseManager.Domain.Entities;

namespace CourseManager.Domain.Interfaces;

//Domain definierar vad som ska göras med data
//men inte hur datan lagras
public interface ICourseRepository
{
    //Hämtar alla kurser från databasen
    List<Course> GetAll();

    //lägger till en ny kurs
    Course Add(Course course);

    //uppdaterar en kurs
    Course Update(int id, Course course);

    //Tar bort en kurs
    void Delete(int id);
}