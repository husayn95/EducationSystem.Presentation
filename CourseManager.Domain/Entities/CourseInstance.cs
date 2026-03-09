namespace CourseManager.Domain.Entities;

/*
 Representerar ett specifikt kurstillfälle.

 Ett kurstillfälle kopplar ihop:
 - en kurs
 - en lärare
*/
public class CourseInstance
{
    // Primärnyckel
    public int Id { get; set; }

    // Foreign key till Course
    public int CourseId { get; set; }

    // Navigering till kursen
    public Course Course { get; set; }

    // Foreign key till Teacher
    public int TeacherId { get; set; }

    // Navigering till läraren
    public Teacher Teacher { get; set; }

    // Datum när kurstillfället börjar
    public DateTime StartDate { get; set; }

    // Navigeringsegenskap:
    // Ett kurstillfälle kan ha många registreringar
    public List<Registration> Registrations { get; set; } = new();
}
