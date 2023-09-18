using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PermitPrice: Auditable, IAuditable
    {
        [Key]
        public int id { get; set; }

        public int PermitTypeId { get; set; }

        public int PermitCategoryId { get; set; }


        public int CurrencyId { get; set; }

        public int PermitActionId { get; set; }

        public string? Value { get; set; }

        public PermitType permitType { get; set; }

        public PermitCategory permitCategory { get; set; }

        public Currency currency { get; set; }

        public PermitAction permitAction { get; set; }
    }
}
