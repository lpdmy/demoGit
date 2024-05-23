using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachMate.Domain;
using TeachMate.Services.SearchModuleService;

namespace TeachMate.Api;
[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchModuleService _searchModuleService;

    public SearchController(ISearchModuleService searchModuleService)
    {
        _searchModuleService = searchModuleService;
    }

    [Authorize(Roles = CustomRoles.Learner)]
    [HttpGet("LearningModule/GetByTitle")]
    public async Task<ActionResult<List<LearningModule>>> GetLearningModuleByTitle(string title)
    {
        return Ok(await _searchModuleService.SearchLearningModuleByTitle(title));
    }
}
