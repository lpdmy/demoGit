using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeachMate.Domain;
public class AppUser
{
    [Key]
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string? Username { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public string? Password { get; set; }
    public bool IsDisabled { get; set; }
    public UserRole UserRole { get; set; } = UserRole.Learner;
    public Tutor? Tutor { get; set; }
    public Learner? Learner { get; set; }
}
