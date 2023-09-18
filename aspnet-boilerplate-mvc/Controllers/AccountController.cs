using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Models;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security;
using System.Security.Cryptography.Xml;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _rolemanager;
        private readonly UserManager<User> _usermanager;
        private readonly IUnitOfWork _unitofwork;

        public AccountController(SignInManager<User> signInManager, RoleManager<Role> roleManager, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _rolemanager = roleManager;
            _usermanager = userManager;
            _unitofwork = unitOfWork;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthModel loginViewModel)
        {
            var user = await _usermanager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                TempData["error"] = "Invalid Login details";
            }
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
                if (signInResult.Succeeded)
                {

                    var obj = _unitofwork.roleUserRepository.GetOne(q => q.UserId == user.Id);
                    if (obj != null)
                    {
                          var myroles = await _usermanager.GetRolesAsync(user);
                        var role = await _rolemanager.FindByIdAsync(obj.RoleId);
                            await _usermanager.RemoveFromRolesAsync(user, myroles);
                            await _usermanager.AddToRoleAsync(user, role.Name);
						var rolepermissions = _unitofwork.rolePermissionRepository.Find(q => q.RoleId == obj.RoleId, new List<string> { "permission" });
                        Task.CompletedTask.Wait();
                        List<string> roles = new List<string>();
                        var dbroles = _unitofwork.roleRepository.GetAll();
                        Task.CompletedTask.Wait();
						foreach (var permission in rolepermissions)
                            {
                                    if (dbroles.Any(q=>q.Name==permission.permission.Name))
                                    {
                                        roles.Add(permission.permission.Name);
                                    }
                            }
						await _usermanager.AddToRolesAsync(user, roles);


					}
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Invalid Login Credetionals";
                }
            }
            return View(loginViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete(".AspNetCore.Session");

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
