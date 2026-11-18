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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitorResponse>>> GetAllVisitors()
    {
        var visitors = await _visitorService.GetAllVisitorsAsync();

        return Ok(visitors);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VisitorResponse>> GetVisitorById(int id)
    {
        var visitor = await _visitorService.GetVisitorByIdAsync(id);

        if (visitor is null)
        {
            return NotFound(new
            {
                message = $"Visitor with ID {id} was not found."
            });
        }

        return Ok(visitor);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateVisitor(
        int id,
        [FromBody] UpdateVisitorRequest request)
    {
        var updated = await _visitorService.UpdateVisitorAsync(id, request);

        if (!updated)
        {
            return NotFound(new
            {
                message = $"Visitor with ID {id} was not found."
            });
        }

        return Ok(new
        {
            message = "Visitor updated successfully."
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteVisitor(int id)
    {
        try
        {
            var deleted = await _visitorService.DeleteVisitorAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = $"Visitor with ID {id} was not found."
                });
            }

            return Ok(new
            {
                message = "Visitor deleted successfully."
            });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new
            {
                message = ex.Message
            });
        }
    }


}