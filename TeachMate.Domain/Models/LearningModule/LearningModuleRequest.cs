using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TeachMate.Domain;
public class LearningModuleRequest
{
    [Key]
    public int Id { get; set; }
    public Guid RequesterId { get; set; }
    public string RequesterDisplayName { get; set; } = string.Empty;
    public Guid TutorId { get; set; }
    public string TutorDisplayName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public Subject Subject { get; set; } = Subject.None;
    // Calculated in minutes
    public int Duration { get; set; }
    public RequestStatus Status { get; set; }
    [JsonIgnore]
    public string SerializedSchedule { get; set; } = string.Empty;
    [NotMapped]
    public List<LearningSession> Schedule { get; set; } = new();
}
