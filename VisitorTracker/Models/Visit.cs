namespace VisitorTracker.Models
{
    public class Visit
    {
        public int Id { get; set; }

        // Foreign keys
        public int VisitorId { get; set; }

        public int EmployeeId { get; set; }

        public required string Purpose { get; set; }

        public DateTime CheckInTimeUtc { get; set; } = DateTime.UtcNow;

        public DateTime? CheckOutTimeUtc { get; set; }

        public VisitStatus Status { get; set; } = VisitStatus.CheckedIn;

        // Navigation properties
        public Visitor Visitor { get; set; } = null!;

        public Employee Employee { get; set; } = null!;
    }
}
