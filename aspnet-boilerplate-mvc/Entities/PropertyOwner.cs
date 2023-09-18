using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PropertyOwner : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Phonenumber { get; set; }

        public string? IdentificationType { get; set; }

        public string? Identification { get; set; }

        public List<PropertyInformation> Properties { get; set; }


    }
}
