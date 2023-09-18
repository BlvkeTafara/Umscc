using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Models;
using aspnet_boilerplate_mvc.Repositories;
using aspnet_boilerplate_mvc.Services.Auths;
using aspnet_boilerplate_mvc.Services.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetTopologySuite.IO;

namespace aspnet_boilerplate_mvc.Controllers
{

	[Authorize(Roles = "User.Index")]
	public class UserController : Controller
	{
		private readonly IUnitOfWork _unitofwork;
		private readonly UserManager<User> _usermanage;
		private readonly IAuthService _authservice;
		private readonly IEmailService _emailservice;

		public UserController(UserManager<User> usermanage, IUnitOfWork unitofwork, IAuthService authservice, IEmailService emailservice)
		{
			_usermanage = usermanage;
			_unitofwork = unitofwork;
			_authservice = authservice;
			_emailservice = emailservice;
		}

		[HttpGet, ActionName("Index")]
		public IActionResult Index()
		{
			var users = _unitofwork.userRepository.GetAll().ToList();
			return View(users);
		}
        [Authorize(Roles = "User.Add")]
        [HttpGet,ActionName("Modify")]
		public async Task<IActionResult> Modify(string? id)
		{
			
			CreateUserModel createusermodel = new CreateUserModel();
			if (id != null) { 
			  var user = _unitofwork.userRepository.GetOne(q=>q.Id == id);
              if(user != null)
				{
					var roleuser = _unitofwork.roleUserRepository.GetOne(q => q.UserId == id);
					createusermodel.Id = user.Id;
					createusermodel.Surname = user.Surname;
					createusermodel.Name = user.Name;
					createusermodel.Email = user.Email;
					createusermodel.RoleId = roleuser.RoleId;
					createusermodel.Enable = user.Enabled;
					createusermodel.Phone = user.PhoneNumber;

				}

			}

			var roles = _unitofwork.roleRepository.Find(q=>q.Type=="System").ToList();	

			UserModel usermodel= new UserModel();
			usermodel.user = createusermodel;
			usermodel.Roles = roles;
			return View(usermodel);	
		}
        [Authorize(Roles = "User.Add")]
        [HttpPost, ActionName("Modify")]
		public async Task<IActionResult> Modify(UserModel model)
		{
			CreateUserModel obj = model.user;
           var checkuser = _unitofwork.userRepository.GetOne(q=>q.Email == obj.Email);
			var password = await _authservice.GeneratePassword();
		 
			if (checkuser != null && obj.Id== null)
			{
				TempData["error"] = "Email already taken";
                return RedirectToAction("Index");

            }
			if(ModelState.IsValid)
			{
				var user =  obj.Id ==null ? new User() : await _usermanage.FindByIdAsync(obj.Id);
				

					user.Name = obj.Name;
					user.Email = obj.Email;
					user.Surname = obj.Surname;
					user.PhoneNumber = obj.Phone;
					user.NormalizedEmail = obj.Email.ToUpper();
					user.UserName = obj.Email;
					user.Gender = obj.Gender;
					user.Enabled = obj.Enable;
					user.NormalizedUserName = obj.Email.ToUpper();

				 IdentityResult response = new IdentityResult();
				if(obj.Id == null)
				{
					response = await _usermanage.CreateAsync(user, password);

				}
				else
				{
                   response= await _usermanage.UpdateAsync(user);
                }
				
				if (response.Succeeded)
				{
                    var roles = await _usermanage.GetRolesAsync(user);

                    var role = _unitofwork.roleRepository.GetOne(q => q.Id == obj.RoleId);

                    if (roles.Count() > 0)
                    {
                        await _usermanage.RemoveFromRolesAsync(user, roles);
                        var userrole = _unitofwork.roleUserRepository.GetOne(q => q.UserId == user.Id && q.RoleId == obj.RoleId);
                        _unitofwork.roleUserRepository.Remove(userrole);
                        await _unitofwork.Save();
                    }
                    RoleUser roleuser = new RoleUser();
                    roleuser.RoleId = obj.RoleId;
                    roleuser.UserId = user.Id;
                    _unitofwork.roleUserRepository.Add(roleuser);
                    var response2 = await _unitofwork.Save();
                    if (response2 > 0)
                    {
                        List<string> newroles = new List<string>();
                        newroles.Add(role.Name);
                        await _usermanage.AddToRolesAsync(user, newroles);
                        await _emailservice.AccountCreationEmail(user.Email, user.Name, password);
                        TempData["success"] = "Account successfully created";
                    }
                    else
                    {
                        TempData["error"] = "An Error has occured";
                    }
				}
				else
				{
					TempData["error"] = response.Errors.FirstOrDefault().Description;
				}

				
                
            }

            return RedirectToAction("Index");

        }
        [Authorize(Roles = "User.Add")]
        [HttpGet, ActionName("ResetPassword")]
		public async Task<IActionResult> ResetPassword(string Id)
		{
			var user = await _usermanage.FindByIdAsync(Id);
			return View(user);
		}
        [Authorize(Roles = "User.Add")]
        [HttpPost, ActionName("ResetPassword")]
        public async Task<IActionResult> ResetPassword(User obj)
        {
            var user = await _usermanage.FindByIdAsync(obj.Id);
			var password = await _authservice.GeneratePassword();
			var token = await _usermanage.GeneratePasswordResetTokenAsync(user);
			var response = await _usermanage.ResetPasswordAsync(user, token, password);
			if(response.Succeeded)
			{
				await _emailservice.ResetPasswordEmail(user.Email,user.Name,password);
				TempData["success"] = "Password successfully reset";
			}
			else
			{
				TempData["error"] = "An error has occured";
			}
			return RedirectToAction("Index");	
        }
    }
}
