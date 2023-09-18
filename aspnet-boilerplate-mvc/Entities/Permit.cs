using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Permit: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int PurposeId { get; set; }

        public int PropertyInformationId { get; set; }

        public int PermitCategoryId { get; set; }

        public string uuid { get; set; }

        public int PermitTypeId { get; set; }

        public string Permitnumber { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public Purpose purpose { get; set; }

        public PropertyInformation property { get; set; }

        public PermitCategory permitcategory { get; set; }

        public PermitType permittype { get; set; }

        public User user { get; set; }
    }
}
