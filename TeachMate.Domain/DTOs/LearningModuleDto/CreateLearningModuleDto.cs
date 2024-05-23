namespace TeachMate.Domain;
public class CreateLearningModuleDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Subject Subject { get; set; } = Subject.None;
    // Calculated in minutes
    public int Duration { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int MaximumLearners { get; set; }
    public List<LearningSession> Schedule { get; set; } = new();
}
