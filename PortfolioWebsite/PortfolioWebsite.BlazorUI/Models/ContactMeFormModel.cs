using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class ContactMeFormModel
    {
        [Required(ErrorMessage = "Field Required.")]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field Required.")]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field Required.")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Must be shorter than 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field Required.")]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Field Required.")]
        [MaxLength(2000, ErrorMessage = "Must be shorter than 2000 characters.")]
        public string Message { get; set; }
    }
}
