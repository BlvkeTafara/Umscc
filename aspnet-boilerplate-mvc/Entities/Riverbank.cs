using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Riverbank : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Rivername { get; set; }

        public string AreaId { get; set; }

        public string longitude { get; set; }

        public string latitude { get; set; }

        public string landsize { get; set; }

    }
}
