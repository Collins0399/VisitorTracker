using VisitorTracker.DTOs;

namespace VisitorTracker.Interfaces
{
    public interface IVisitorService
    {
        Task RegisterVisitorAsync(RegisterVisitorRequest request);
        Task<IEnumerable<VisitorResponse>> GetAllVisitorsAsync();
        Task<VisitorResponse?> GetVisitorByIdAsync(int id);
        Task<bool> UpdateVisitorAsync(int id, UpdateVisitorRequest request);
        Task<bool> DeleteVisitorAsync(int id);
    }
}
