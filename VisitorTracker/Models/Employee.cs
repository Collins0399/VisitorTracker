namespace VisitorTracker.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Department { get; set; }

        public string? Email { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation property: an employee can receive multiple visits.
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
