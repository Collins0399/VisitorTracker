using System.ComponentModel.DataAnnotations;

namespace VisitorTracker.DTOs
{
    public class RegisterVisitorRequest
    {
       
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2)]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2)]
        public required string LastName { get; set; }

        [Phone(ErrorMessage = "Please provide a valid phone number.")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? Organization { get; set; }
    }

}
