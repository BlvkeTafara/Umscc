using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Suburb : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public Area area { get; set; }
    }
}
