namespace CourseManager.Domain.Entities;

/*
 Representerar en deltagare i systemet.

 En deltagare kan registrera sig på flera kurstillfällen.
*/
public class Participant
{
    // Primärnyckel
    public int Id { get; set; }

    // Deltagarens namn
    public string Name { get; set; }

    // Navigeringsegenskap:
    // En deltagare kan ha flera kursregistreringar
    public List<Registration> Registrations { get; set; } = new();
}
