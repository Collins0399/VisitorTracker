namespace VisitorTracker.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Organization { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        // Navigation property: a visitor can have multiple visits.
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
