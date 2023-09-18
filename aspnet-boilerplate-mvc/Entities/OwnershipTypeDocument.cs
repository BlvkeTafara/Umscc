using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class OwnershipTypeDocument: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int OwnershipTypeId { get; set; }

        public int DocumentId { get; set; }

        public OwnershipType ownershipType { get; set; }

        public Document document { get; set; }
    }
}
