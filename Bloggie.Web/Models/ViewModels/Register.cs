using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        public string Email { get; set; }
    }
}
