using Microsoft.AspNetCore.Mvc;
using TeachMate.Domain;
using TeachMate.Services;

namespace TeachMate.Api;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Login with Username and Password
    /// </summary>
    [HttpPost("Login")]
    public async Task<ActionResult<LoginPayloadDto>> Login(UserCredentialDto dto)
    {
        return Ok(await _authService.Login(dto));
    }

    /// <summary>
    /// Signin with google
    /// </summary>
    [HttpPost("GoogleSignIn")]
    public async Task<ActionResult<LoginPayloadDto>> GoogleSignIn(GoogleSignInVM dto)
    {
        return Ok(await _authService.SignInWithGoogle(dto));
    }

    /// <summary>
    /// Signup with Username and Password
    /// </summary>
    [HttpPost("SignUp")]
    public async Task<ActionResult<LoginPayloadDto>> Signup(CreateUserDto dto)
    {
        return Ok(await _authService.Signup(dto));
    }

    /// <summary>
	/// Get Current User
	/// </summary>
    [HttpGet("Me")]
    public async Task<ActionResult<AppUser>> GetMe()
    {
        return Ok(await _authService.GetMe());
    }
}
