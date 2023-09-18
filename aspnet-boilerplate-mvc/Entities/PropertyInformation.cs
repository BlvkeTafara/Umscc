using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PropertyInformation : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int? PropertyOwnerId { get; set; }

        public string? Accountnumber { get; set; }

        public string? StreetNumber { get; set; }

        public string? StreetName { get; set; }
        public string? Address { get; set; }

        public string? NormalizeAddress { get; set; }

        public int AreaId { get; set; }

        public int SuburbId { get; set; }

        public int PropertyTypeId { get; set; }

        public int OwnershipTypeId { get; set; }

        public string? Landsize { get; set; }

        public int UomId { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        public PropertyOwner? owner { get; set; }

        public PropertyType propertyType { get; set; }

        public OwnershipType ownershipType { get; set; }

        public Area area { get; set; }

        public Suburb suburb { get; set; }

        public Uom uom { get; set; }

        public List<Permit> permits { get; set; }

    }
}
