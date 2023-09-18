using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class AbstractionSetting: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }
        public int PermitTypeId { get; set; }
        public int PurposeId { get; set; }
        public int UomId { get; set; }
        public string Value { get; set; }
        public string Period { get; set; }
        public PermitType permitType { get; set; }
        public Purpose purpose { get; set; }
        public Uom uom { get; set; }
    }
}
