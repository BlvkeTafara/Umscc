using Microsoft.AspNetCore.Identity;

namespace aspnet_boilerplate_mvc.Entities
{
    public class User:IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public bool Enabled { get; set; }

        public RoleUser roleuser { get; set; }
    }
}
