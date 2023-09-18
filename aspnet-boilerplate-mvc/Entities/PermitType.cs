using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PermitType: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string code { get; set; }
        public string Status { get; set; }
        public List<PermitTypeDocument> permittypedocuments { get; set; }
        public List<AbstractionSetting> abstractionSettings { get; set; }

        public List<PermitPrice> prices { get; set; }
    }
}
