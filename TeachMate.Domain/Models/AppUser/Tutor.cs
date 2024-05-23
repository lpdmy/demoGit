using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeachMate.Domain;
public class Tutor
{
    [Key]
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public List<LearningModule> CreatedModules { get; set; } = new List<LearningModule>();
    [JsonIgnore]
    public AppUser AppUser { get; set; } = null!;
}
