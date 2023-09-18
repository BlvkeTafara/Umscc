using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Models;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace aspnet_boilerplate_mvc.Controllers
{
	[Authorize(Roles = "Role.Index")]
	public class RoleController : Controller
	{
		private readonly IUnitOfWork _unitofwork;
		private readonly RoleManager<Role> _roleManager;
		public RoleController(IUnitOfWork unitofwork, RoleManager<Role> roleManager)
		{
			_unitofwork = unitofwork;
			_roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var roles = _unitofwork.roleRepository.Find(q=>q.Type=="System").ToList();
			return View(roles);
		}
        [Authorize(Roles = "Role.Add")]
        [HttpGet, ActionName("Modify")]
		public async Task<IActionResult> Modify(string? id) {
			RoleModel rolemodel = new RoleModel();
			if (!id.IsNullOrEmpty())
			{
				var role = _unitofwork.roleRepository.GetOne(q=>q.Id == id);
				rolemodel.Id = id;
				rolemodel.Name = role.Name;
			}
			return View(rolemodel);
		}

        [Authorize(Roles = "Role.Add")]
        [HttpPost,ActionName("Modify")]
		public async Task<IActionResult> Modify(RoleModel obj)
		{
			if (obj.Id.IsNullOrEmpty())
			{
				Role role = new Role();
				role.Name = obj.Name;
				role.Type = "System";
				role.Level = obj.Level;	
				role.NormalizedName = obj.Name.ToUpper();
				var result = await _roleManager.CreateAsync(role);
				if (result.Succeeded)
				{
					TempData["success"] = "Role successfully created";
				}
				else
				{
					TempData["error"] = "An error has occured";
				}
			}
			else
			{
				var role = await _roleManager.FindByIdAsync(obj.Id);
				if (role == null)
				{
					TempData["error"] = "Role not found";
				}
				else
				{
					role.NormalizedName = obj.Name.ToUpper();
					role.Name = obj.Name;
					role.Type = "System";
					role.Level = obj.Level;	
					var result = await _roleManager.UpdateAsync(role);
					if (result.Succeeded)
					{
						TempData["success"] = "Role successfully updated";
					}
					else
					{
						TempData["error"] = "An error has occured";
					}

				}
			}
			return RedirectToAction("Index");
		}
        [Authorize(Roles = "Role.Delete")]
        [HttpGet, ActionName("Delete")]
		public async Task<IActionResult> Delete(string id)
		{
			var role = await _roleManager.FindByIdAsync(id); 
			if (role == null) {
				TempData["error"] = "Role not found";
				return RedirectToAction("Index");
			}
			RoleModel model = new RoleModel();
			model.Id = id;
			model.Name = role.Name;
			return View(model);
		}
        [Authorize(Roles = "Role.Delete")]
        [HttpPost,ActionName("Delete")]
		public async Task<IActionResult> Delete(RoleModel obj)
		{
			var role = await _roleManager.FindByIdAsync (obj.Id);
			if (role == null)
			{
				TempData["error"] = "Role not found";

			}
			else {
				var result = await _roleManager.DeleteAsync(role);
				if (result.Succeeded)
				{
					TempData["success"] = "Role successfully deleted";
				}
			}
			return RedirectToAction("Index");
		}



	}
}
