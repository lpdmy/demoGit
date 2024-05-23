using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachMate.Domain;

namespace TeachMate.Api;
[Authorize(CustomRoles.Admin)]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
}
