using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace aspnet_boilerplate_mvc.Controllers
{
    [Authorize(Roles = "Submodule.Index")]
    public class PermissionController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly RoleManager<Role> _roleManager;
		public PermissionController(IUnitOfWork unitofwork, RoleManager<Role> roleManager)
		{
			_unitofwork = unitofwork;
			_roleManager = roleManager;
		}
		public IActionResult Index(int id)
        {
            var module = _unitofwork.submoduleRepository.GetOne(q => q.Id == id, new List<string> { "Permissions" });
            return View(module);
        }
        [Authorize(Roles = "Submodule.Add")]
        [HttpGet, ActionName("Modify")]
        public IActionResult Modify(int? id, int submoduleId)
        {
            Permission permission = new Permission() { SubmoduleId =submoduleId };
            if (id.HasValue)
            {
                permission = _unitofwork.permissionRepository.GetOne(q => q.Id == id);
            }
            return View(permission);
        }
        [Authorize(Roles = "Submodule.Add")]
        [HttpPost, ActionName("Modify")]
        public async Task<IActionResult> Modify(Permission obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitofwork.permissionRepository.Add(new Permission { Name = obj.Name, SubmoduleId=obj.SubmoduleId });
                }
                else
                {
                    _unitofwork.permissionRepository.Update(obj);
                }
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    var checkrole = await _roleManager.RoleExistsAsync(obj.Name);
                    if (!checkrole)
                    {
                       await _roleManager.CreateAsync(new Role { Name = obj.Name,Type="Permission" });
                    }
                    TempData["success"] = "Permission successfully modified";
                }
                else
                {
                    TempData["error"] = "An error has occured";
                }
                return RedirectToAction("Index", new { id = obj.SubmoduleId });
            }
            return View(obj);

        }
        [Authorize(Roles = "Submodule.Delete")]
        [HttpGet, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var record = _unitofwork.permissionRepository.GetOne(q => q.Id == id);
            return View(record);
        }
        [Authorize(Roles = "Submodule.Delete")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Permission obj)
        {
            _unitofwork.permissionRepository.Remove(obj);
            var id = obj.SubmoduleId;
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                TempData["success"] = "Record successfully deleted";
            }
            else
            {
                TempData["error"] = "An error has occured";
            }
            return RedirectToAction("Index", new { id = id });
        }
    }
}
