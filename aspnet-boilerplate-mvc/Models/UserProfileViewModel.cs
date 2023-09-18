using aspnet_boilerplate_mvc.Entities;
using Microsoft.AspNetCore.Identity;

namespace aspnet_boilerplate_mvc.Models
{
    public class UserProfileViewModel
    {
        public SignInManager<User> signInManager { get; set; }

        public List<Module> systemmodules
        {
            get; set;
        }
    }
}
