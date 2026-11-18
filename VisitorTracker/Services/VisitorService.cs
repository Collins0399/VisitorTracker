using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<VisitorResponse>> GetAllVisitorsAsync()
    {
        var visitors = await _context.Visitors
            .Select(visitor => new VisitorResponse
            {
                Id = visitor.Id,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                PhoneNumber = visitor.PhoneNumber,
                Email = visitor.Email,
                Organization = visitor.Organization,
                CreatedAtUtc = visitor.CreatedAtUtc
            })
            .ToListAsync();

        return visitors;
    }

    public async Task<VisitorResponse?> GetVisitorByIdAsync(int id)
    {
        var visitor = await _context.Visitors
            .Where(visitor => visitor.Id == id)
            .Select(visitor => new VisitorResponse
            {
                Id = visitor.Id,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                PhoneNumber = visitor.PhoneNumber,
                Email = visitor.Email,
                Organization = visitor.Organization,
                CreatedAtUtc = visitor.CreatedAtUtc
            })
            .FirstOrDefaultAsync();

        return visitor;
    }

    public async Task<bool> UpdateVisitorAsync(
        int id,
        UpdateVisitorRequest request)
    {
        var visitor = await _context.Visitors
            .FirstOrDefaultAsync(visitor => visitor.Id == id);

        if (visitor is null)
        {
            return false;
        }

        visitor.FirstName = request.FirstName.Trim();
        visitor.LastName = request.LastName.Trim();
        visitor.PhoneNumber = request.PhoneNumber;
        visitor.Email = request.Email;
        visitor.Organization = request.Organization;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteVisitorAsync(int id)
    {
        var visitor = await _context.Visitors
            .FirstOrDefaultAsync(visitor => visitor.Id == id);

        if (visitor is null)
        {
            return false;
        }

        var hasVisits = await _context.Visits
            .AnyAsync(visit => visit.VisitorId == id);

        if (hasVisits)
        {
            throw new InvalidOperationException(
                "Cannot delete a visitor who has existing visit records.");
        }

        _context.Visitors.Remove(visitor);

        await _context.SaveChangesAsync();

        return true;
    }


}
