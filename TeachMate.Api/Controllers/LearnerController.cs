using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachMate.Domain;

namespace TeachMate.Api;
[Authorize(Roles = CustomRoles.Learner)]
[Route("api/[controller]")]
[ApiController]
public class LearnerController : ControllerBase
{
}
