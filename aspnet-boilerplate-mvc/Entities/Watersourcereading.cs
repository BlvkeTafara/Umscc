using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Watersourcereading : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int WatersourceId { get; set; }

        public string? reading { get; set; }

        public int Year { get; set; }

        public string Readingdate { get; set; }

        public string? Month { get; set; }


        [AllowNull]
        public string? condition { get; set; }

        public int UserId { get; set; }

        public User user { get; set; }
    }
}
