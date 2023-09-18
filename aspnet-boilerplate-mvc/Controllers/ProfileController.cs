using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Models;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<User> _userManager;
        public ProfileController(IUnitOfWork unitofwork, IHttpContextAccessor http, UserManager<User> userManager = null)
        {
            _unitofwork = unitofwork;
            _http = http;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var userId = _http.HttpContext.User.Claims.First().Value;
            var user = _unitofwork.userRepository.GetOne(q => q.Id == userId);
            if (user == null)
            {
                TempData["error"] = "Unauthorized";
            }
            UserProfileModel profile  = new UserProfileModel();
            profile.Id = user.Id; 
            profile.Name = user.Name;
            profile.Surname = user.Surname;
            profile.Gender = user.Gender;
            profile.Email = user.Email;
            profile.Phone = user.PhoneNumber;
            return View(profile);
        }

        [HttpPost,ActionName("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(UserProfileModel userprofile)
        {
            User user = await _userManager.FindByIdAsync(userprofile.Id);

            user.Name = userprofile.Name;   
            user.Surname = userprofile.Surname;
            user.Gender = userprofile.Gender;
            user.Email = userprofile.Email;
            user.PhoneNumber = userprofile.Phone;
            var response = await _userManager.UpdateAsync(user);
            if(response.Succeeded)
            {
                TempData["success"] = "Account Successfully Updated";
            }
            else
            {
                TempData["error"] = "An error has occured";
            }
            return RedirectToAction("Index","Home");
        }

        [HttpGet,ActionName("ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            var userId = _http.HttpContext.User.Claims.First().Value;
             ChangePasswordModel changePasswordModel = new ChangePasswordModel();
            changePasswordModel.userId = userId;
            return View(changePasswordModel);
        }

        [HttpPost, ActionName("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(changePasswordModel.userId);
               var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var response = await _userManager.ResetPasswordAsync(user, token,changePasswordModel.ConfirmPassword);
                if(response.Succeeded)
                {
                    TempData["success"] = "Password successfully changed";
                }
                else
                {
                    TempData["error"] = "An error has occured during password reset";
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
