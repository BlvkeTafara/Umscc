using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_boilerplate_mvc.Entities
{
    public class ExchangeRate: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
        public int PrimaryCurrencyId { get; set; }

        public int SecondaryCurrencyId { get; set; }

        public string Value { get; set; }

        [ForeignKey("PrimaryCurrencyId")]
        public Currency? primarycurrency { get; set; }

        [ForeignKey("SecondaryCurrencyId")]
        public Currency? secondarycurrency { get; set; }
    }
}
