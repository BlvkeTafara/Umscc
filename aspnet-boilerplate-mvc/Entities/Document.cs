using aspnet_boilerplate_mvc.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Document: Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
