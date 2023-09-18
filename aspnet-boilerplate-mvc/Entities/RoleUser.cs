using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class RoleUser
    {
        [Key]
        public int Id { get; set; }

        public string RoleId { get; set; }

        public string UserId { get; set; }

        public Role role { get; set; }
    }
}
