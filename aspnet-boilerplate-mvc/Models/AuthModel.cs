using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Models
{
    public class AuthModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }    
    }
}
