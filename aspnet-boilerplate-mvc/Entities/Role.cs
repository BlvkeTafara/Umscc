using Microsoft.AspNetCore.Identity;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Role:IdentityRole
    {
        public string? Type { get; set; }
        public string?  Level { get; set; }
        public List<RolePermission> Permissions { get; set; }
    }
}
