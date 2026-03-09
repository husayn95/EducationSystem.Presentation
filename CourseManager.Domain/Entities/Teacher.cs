namespace CourseManager.Domain.Entities;

/*
 Representerar en lärare i systemet.

 En lärare kan hålla flera kurstillfällen.
*/
public class Teacher
{
    // Primärnyckel
    public int Id { get; set; }

    // Lärarens namn
    public string Name { get; set; }

    // Navigeringsegenskap:
    // En lärare kan undervisa på flera kurstillfällen
    public List<CourseInstance> CourseInstances { get; set; } = new();
}
