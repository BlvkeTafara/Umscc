using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Models;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Components
{
    public class SideBarViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<User> _signInManager;
        public SideBarViewComponent(IUnitOfWork unitOfWork, SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _unitOfWork.moduleRepository.GetAll(new List<string> { "submodules" }).ToList();

            UserProfileViewModel profile = new UserProfileViewModel() { signInManager = _signInManager, systemmodules = model };

            return await Task.FromResult((IViewComponentResult)View("SideBar", profile));
        }
    }
}
