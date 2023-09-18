using aspnet_boilerplate_mvc.Entities;

namespace aspnet_boilerplate_mvc.Services.Auths
{
	public interface IAuthService
	{
		Task<string> GeneratePassword();

	}
}
