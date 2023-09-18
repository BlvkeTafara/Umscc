using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Rainreading : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int RainmonitorId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public string reading { get; set; }

        public string Readingdate { get; set; }

        public int UomId { get; set; }
        public int UserId { get; set; }

        public Uom Uom { get; set; }
    }
}
