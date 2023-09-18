using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PermitTypeDocument : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public int PermitTypeId { get; set; }

        public int PermitCategoryId { get; set; }
        public Document document { get; set; }

        public PermitType permitType { get; set; }

        public PermitCategory permitCategory { get; set; }

        public List<PermitTypeDocumentExemption> exemptions { get; set; }
    }
}
