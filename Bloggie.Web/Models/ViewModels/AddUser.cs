using Microsoft.Net.Http.Headers;

namespace Bloggie.Web.Models.ViewModels
{
    public class AddUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool AdminCheckbox { get; set; }
    }
}
