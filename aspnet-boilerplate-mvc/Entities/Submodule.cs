using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Submodule:Auditable,IAuditable
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ModuleId { get; set; }

        [Required]
        public string Icon { get; set; }

        [Required]
        public string Controller { get; set; }

        [Required]
        public string DefaultAction { get; set; }

        public List<Permission>? Permissions { get; set; }
    }
}
