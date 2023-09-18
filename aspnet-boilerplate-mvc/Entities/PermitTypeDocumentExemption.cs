using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PermitTypeDocumentExemption : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int PermitTypeDocumentId { get; set; }

        public int PurposeId { get; set; }


        public PermitTypeDocument permitTypeDocument { get; set; }

        public Purpose purpose { get; set; }
    }
}
