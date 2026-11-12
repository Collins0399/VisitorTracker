using VisitorTracker.DTOs;

namespace VisitorTracker.Interfaces
{
    public interface IVisitorService
    {
        Task RegisterVisitorAsync(RegisterVisitorRequest request);
    }
}
