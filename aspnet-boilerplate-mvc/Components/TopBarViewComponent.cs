using aspnet_boilerplate_mvc.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Components
{
	public class TopBarViewComponent:ViewComponent
	{
		private readonly SignInManager<User> _signInManager;
		public TopBarViewComponent(SignInManager<User> signInManager)
		{
			_signInManager = signInManager;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult((IViewComponentResult)View("TopBar", _signInManager));
		}
	}
}
