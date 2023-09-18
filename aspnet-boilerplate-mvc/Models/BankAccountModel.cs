using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Models
{
    public class BankAccountModel
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public int BankId { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
