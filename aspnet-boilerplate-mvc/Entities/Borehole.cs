using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Borehole: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }
        public int PropertyInformationId { get; set; }
        public string? Bhnumber { get; set; }
        public string? Gridreference { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set;}
        public string? Depth { get; set;}
        public string? Sampling { get; set; }
        public int PurposeId { get; set; }
        public string? AbstractionRate { get; set; }
        public Purpose? purpose { get; set; }
        public PropertyInformation? propertyInformation { get; set; }
        public List<Permit>? permits { get; set; }
    }
}
