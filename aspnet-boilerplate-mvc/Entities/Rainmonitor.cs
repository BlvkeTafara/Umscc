using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Rainmonitor : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int AreaId { get; set; }

        public string? Instrument { get; set; }

        public string? longitude { get; set; }

        public string? latitude { get; set; }

        public Area? area { get; set; }

        public List<Rainreading>? Rainreading { get; set; }
    }
}
