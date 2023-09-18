using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Currency: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
