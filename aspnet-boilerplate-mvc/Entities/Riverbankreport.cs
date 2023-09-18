using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Riverbankreport : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int RiverbankId { get; set; }

        public string? description { get; set; }

        public int occupiedlandsize { get; set; }

        public List<RiverbankreportImage> images { get; set; }
    }
}
