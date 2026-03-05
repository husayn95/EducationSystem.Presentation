namespace CourseManager.Domain.Entities;

//Entity som representerar en kurs i systemet
//Domain innehåller endast data och affärsregler
public class Course
{
    //Primärnyckel i databasen.
    //EF Core använder denna automatiskt som ID
    public int Id { get; set; }

    //Namnet på kursen
    public string Title { get; set; }

    //namnet på läraren som håller kursen
    public string Teacher { get; set; }
}
