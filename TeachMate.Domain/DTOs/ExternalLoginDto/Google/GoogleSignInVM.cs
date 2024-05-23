using System.ComponentModel.DataAnnotations;

namespace TeachMate.Domain;
public class GoogleSignInVM
{
    [Required]
    public string IdToken { get; set; }
    public UserRole UserRole { get; set; } = UserRole.Learner;
}