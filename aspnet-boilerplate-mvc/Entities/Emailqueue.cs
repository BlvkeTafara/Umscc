using System.ComponentModel.DataAnnotations;

namespace aspnet_boilerplate_mvc.Entities
{
    public class Emailqueue
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Url { get; set; } = string.Empty;


        public string Subject { get; set; } = string.Empty;

        public string BodyHtml { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
