using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Wetlandreport : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int WetlandId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public string Reportdate { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string occupiedlandsize { get; set; }

        public int UomId { get; set; }

        public int UserId { get; set; }

        public User user { get; set; }

        public List<WetlandreportImage> Images { get; set; }

        public Uom uom { get; set; }
    }
}
