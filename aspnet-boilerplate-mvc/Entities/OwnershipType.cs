using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class OwnershipType: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
    }
}
