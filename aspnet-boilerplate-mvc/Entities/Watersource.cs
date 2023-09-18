using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Watersource : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SourcetypeId { get; set; }

        public int AreaId { get; set; }

        public string? latitude { get; set; }

        public string? longitude { get; set; }

        public string capacity { get; set; }

        public int UomId { get; set; }

        public Area area { get; set; }

        public Uom uom { get; set; }

        public Sourcetype sourcetype { get; set; }

        public List<Watersourcereading> readings { get; set; }


    }
}
