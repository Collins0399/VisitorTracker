using Microsoft.AspNetCore.Mvc;
using VisitorTracker.DTOs;
using VisitorTracker.Interfaces;

namespace VisitorTracker.Controllers;

[ApiController]
[Route("api/visitors")]
public class VisitorsController : ControllerBase
{
    private readonly IVisitorService _visitorService;

    public VisitorsController(IVisitorService visitorService)
    {
        _visitorService = visitorService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterVisitor(
        [FromBody] RegisterVisitorRequest request)
    {
        await _visitorService.RegisterVisitorAsync(request);

        return Ok(new
        {
            message = "Visitor registered successfully."
        });
    }
}