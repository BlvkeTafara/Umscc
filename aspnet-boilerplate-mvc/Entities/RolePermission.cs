using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class RolePermission:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string RoleId { get; set; }

        public int PermissionId { get; set; }

        public Permission? permission { get; set; }
    }
}
