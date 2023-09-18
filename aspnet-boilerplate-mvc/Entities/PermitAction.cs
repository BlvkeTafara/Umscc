using aspnet_boilerplate_mvc.Interfaces;

namespace aspnet_boilerplate_mvc.Entities
{
    public class PermitAction: Auditable, IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
