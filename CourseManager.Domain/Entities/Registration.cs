namespace CourseManager.Domain.Entities;

/*
 Representerar en registrering till ett kurstillfälle.

 Detta är en koppling mellan:
 - Participant (deltagare)
 - CourseInstance (kurstillfälle)
*/
public class Registration
{
    // Primärnyckel
    public int Id { get; set; }

    // Foreign key till Participant
    public int ParticipantId { get; set; }

    // Navigering till deltagaren
    public Participant Participant { get; set; }

    // Foreign key till CourseInstance
    public int CourseInstanceId { get; set; }

    // Navigering till kurstillfället
    public CourseInstance CourseInstance { get; set; }
}
