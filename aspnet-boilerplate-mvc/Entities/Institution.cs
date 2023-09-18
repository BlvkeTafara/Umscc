using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Institution:Auditable,IAuditable
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }    
    }
}
