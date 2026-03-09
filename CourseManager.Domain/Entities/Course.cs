namespace CourseManager.Domain.Entities;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    // TEMPORÄR lösning för frontend
    public string Teacher { get; set; } = string.Empty;

    public List<CourseInstance> CourseInstances { get; set; } = new();
}