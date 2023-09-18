using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Models
{
    public class ChangePasswordModel
    {
        public string userId { get; set; }


        [Required] 
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
