namespace TeachMate.Domain;
public class CreateLearningModuleRequestDto
{
    public Guid TutorId { get; set; }
    public string TutorDisplayName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public Subject Subject { get; set; } = Subject.None;
    // Calculated in minutes
    public int Duration { get; set; }
    public List<LearningSession> Schedule { get; set; } = new();
}
