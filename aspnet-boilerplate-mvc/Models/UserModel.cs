using aspnet_boilerplate_mvc.Entities;

namespace aspnet_boilerplate_mvc.Models
{
	public class UserModel
	{
		public List<Role>? Roles { get; set; }
		public CreateUserModel user { get; set; }
	}
}
