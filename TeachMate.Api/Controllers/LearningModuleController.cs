using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachMate.Domain;
using TeachMate.Services;

namespace TeachMate.Api;
[Route("api/[controller]")]
[ApiController]
public class LearningModuleController : ControllerBase
{
    private readonly IHttpContextService _contextService;
    private readonly ILearningModuleService _learningModuleService;

    public LearningModuleController(ILearningModuleService learningModuleService, IHttpContextService contextService)
    {
        _learningModuleService = learningModuleService;
        _contextService = contextService;
    }

    /// <summary>
    /// Get All Created Modules
    /// </summary>
    [Authorize(Roles = CustomRoles.Tutor)]
    [HttpGet("Tutor/GetAll")]
    public async Task<ActionResult<List<LearningModule>>> GetAllCreatedModules()
    {
        var user = await _contextService.GetAppUserAndThrow();
        return Ok(await _learningModuleService.GetAllCreatedModules(user));
    }

    /// <summary>
    /// Get All Enrolled Modules
    /// </summary>
    [Authorize(Roles = CustomRoles.Learner)]
    [HttpGet("Learner/GetAll")]
    public async Task<ActionResult<List<LearningModule>>> GetAllEnrolledModules()
    {
        var user = await _contextService.GetAppUserAndThrow();
        return Ok(await _learningModuleService.GetAllEnrolledModules(user));
    }

    // TODO: Add filter here to check if learning module created by or enrolled by current user
    /// <summary>
    /// Get LearningModule by Id
    /// </summary>
    [Authorize(Roles = CustomRoles.GeneralUser)]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<LearningModule?>> GetLearningModuleById(int id)
    {
        return Ok(await _learningModuleService.GetLearningModuleById(id));
    }

    /// <summary>
    /// Enroll Learning Module
    /// </summary>
    [Authorize(Roles = CustomRoles.Learner)]
    [HttpPost("{moduleId:int}/Enroll")]
    public async Task<ActionResult<LearningModule>> EnrollLearningModule(int moduleId)
    {
        var user = await _contextService.GetAppUserAndThrow();
        return Ok(await _learningModuleService.EnrollLearningModule(user, moduleId));
    }

    /// <summary>
    /// Create Learning Module
    /// </summary>
    [Authorize(Roles = CustomRoles.Tutor)]
    [HttpPost("Create")]
    public async Task<ActionResult<LearningModule>> CreateLearningModule(CreateLearningModuleDto dto)
    {
        var user = await _contextService.GetAppUserAndThrow();
        return Ok(await _learningModuleService.CreateLearningModule(user, dto));
    }

    /// <summary>
    /// Get all received requests
    /// </summary>
    [Authorize(Roles = CustomRoles.Tutor)]
    [HttpGet("Request/Tutor/GetAll")]
    public async Task<ActionResult<List<LearningModuleRequest>>> GetAllReceivedRequests()
    {
        var user = await _contextService.GetAppUserAndThrow();
        return Ok(await _learningModuleService.GetAllReceivedRequests(user.Id));
    }

    /// <summary>
    /// Get all created requests
    /// </summary>
    [Authorize(Roles = CustomRoles.Learner)]
    [HttpGet("Request/Learner/GetAll")]
    public async Task<ActionResult<List<LearningModuleRequest>>> GetAllCreatedRequests()
    {
        var user = await _contextService.GetAppUserAndThrow();
        return Ok(await _learningModuleService.GetAllCreatedRequests(user.Id));
    }

    // TODO: Add filter here to check if request created by or applied to current user
    /// <summary>
    /// Get Request by Id
    /// </summary>
    [Authorize(Roles = CustomRoles.GeneralUser)]
    [HttpGet("Request/{id:int}")]
    public async Task<ActionResult<LearningModuleRequest?>> GetRequestById(int id)
    {
        return Ok(await _learningModuleService.GetRequestById(id));
    }

    /// <summary>
    /// Create Learning Module Request
    /// </summary>
    [Authorize(Roles = CustomRoles.Learner)]
    [HttpPost("Request/Create")]
    public async Task<ActionResult<LearningModuleRequest>> CreateLearningModuleRequest(CreateLearningModuleRequestDto dto)
    {
        var user = await _contextService.GetAppUserAndThrow();
        return Ok(await _learningModuleService.CreateLearningModuleRequest(user, dto));
    }

    // TODO: Add filter to validate if current user is the one modify the request status or not
    /// <summary>
    /// Update Request Status
    /// </summary>
    [Authorize(Roles = CustomRoles.Tutor)]
    [HttpPut("Request/{requestId:int}/UpdateStatus")]
    public async Task<ActionResult<LearningModuleRequest>> UpdateRequestStatus(int requestId, UpdateRequestStatusDto dto)
    {
        return Ok(await _learningModuleService.UpdateRequestStatus(requestId, dto));
    }
}
