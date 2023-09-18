using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class BankAccount: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int BankId { get; set; }
        public int CurrencyId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public Currency Currency { get; set; }
    }
}
