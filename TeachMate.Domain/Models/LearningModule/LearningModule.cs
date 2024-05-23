using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TeachMate.Domain;
public class LearningModule
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Subject Subject { get; set; } = Subject.None;
    // Calculated in minutes
    public int Duration { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    [NotMapped]
    public List<LearningSession> Schedule { get; set; } = new();
    [JsonIgnore]
    public string SerializedSchedule { get; set; } = string.Empty;
    public int MaximumLearners { get; set; }
    public Guid TutorId { get; set; }
    [JsonIgnore]
    public Tutor Tutor { get; set; } = new Tutor();
    public List<Learner> EnrolledLearners { get; set; } = new List<Learner>();
}
