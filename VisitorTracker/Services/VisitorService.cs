
using VisitorTracker.Data;
using VisitorTracker.DTOs;
using VisitorTracker.Interfaces;
using VisitorTracker.Models;

namespace VisitorTracker.Services;

public class VisitorService : IVisitorService
{
    private readonly ApplicationDbContext _context;

    public VisitorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task RegisterVisitorAsync(RegisterVisitorRequest request)
    {
        var visitor = new Visitor
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Organization = request.Organization
        };

        _context.Visitors.Add(visitor);

        await _context.SaveChangesAsync();
    }
}
