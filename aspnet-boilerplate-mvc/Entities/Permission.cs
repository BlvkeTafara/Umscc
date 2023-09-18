using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Permission:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SubmoduleId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<RolePermission>? rolepermissions { get; set; }
    }
}
