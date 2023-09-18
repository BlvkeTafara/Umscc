using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.WebSockets;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class AssignPermissionController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly RoleManager<Role> _roleManager;
        public AssignPermissionController(IUnitOfWork unitOfWork, RoleManager<Role> roleManager)
        {
            _unitofwork = unitOfWork;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string roleId)
        {
            var role = _unitofwork.roleRepository.GetOne(q=>q.Id==roleId);
            var modules = await _unitofwork.moduleRepository.GetByRole(roleId);
            AssignPermissionModel model = new AssignPermissionModel();
            model.role = role;
            model.modules = modules;
            return View(model);
        }
        [Authorize(Roles = "Role.Assign")]

        [HttpGet,ActionName("Assign")]
        public async Task<IActionResult> Assign(string roleId,int permissionId,string instruction)
        {
            
            if (instruction == "ASSIGN")
            {
                var check = _unitofwork.rolePermissionRepository.GetOne(q => q.PermissionId == permissionId && q.RoleId == roleId);
                if (check != null)
                {
                    TempData["error"] = "Permission already Assigned to Role";
                }
                else
                {
                    RolePermission rolepermission = new RolePermission();
                    rolepermission.RoleId = roleId;
                    rolepermission.PermissionId = permissionId;
                    _unitofwork.rolePermissionRepository.Add(rolepermission);
                    var result = await _unitofwork.Save();
                    if(result>0)
                    {
                        TempData["success"] = "Permission successfully assigned to role";
                    }
                    else
                    {
                        TempData["error"] = "An error has occured while attempting to assign permission";
                    }
                }
            }
            else
            {
                var check = _unitofwork.rolePermissionRepository.GetOne(q => q.PermissionId == permissionId && q.RoleId == roleId);
                if (check == null)
                {
                    TempData["error"] = "Permission not assigned to role";
                }
                else
                {
                    _unitofwork.rolePermissionRepository.Remove(check);
                    var result = await _unitofwork.Save();
                    if(result>0)
                    {
                        TempData["success"] = "Permission successfully removed from role";
                    }
                    else
                    {
                        TempData["error"] = "An error has occured while attempting to remove permission";
                    }
                }
            }
            return RedirectToAction("Index", new {roleId=roleId});
        }
        [Authorize(Roles = "Role.Assign")]
        [HttpGet, ActionName("AssignAll")]
        public async Task<IActionResult> AssignAll(string roleId)
        {
            var permissions = _unitofwork.permissionRepository.GetAll();
            List<RolePermission> rolepermissions = new List<RolePermission>();
            if(permissions.Count() > 0)
            {
                var dbrolepermissions = _unitofwork.rolePermissionRepository.Find(q => q.RoleId == roleId);
                foreach (var item in permissions)
                {
                    if(dbrolepermissions.Where(q=>q.PermissionId==item.Id && q.RoleId==roleId).FirstOrDefault()==null)
                    {
                        RolePermission permission = new RolePermission();
                        permission.RoleId = roleId; 
                        permission.PermissionId = item.Id;
                        rolepermissions.Add(permission);

                    }
                }
            }
            if(rolepermissions.Count() > 0)
            {
                _unitofwork.rolePermissionRepository.BulkInsert(rolepermissions);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    TempData["success"] = "Permissions successfully assigned to role";
                }
                else
                {
                    TempData["error"] = "No records effected";
                }
            }
            else
            {
                TempData["error"] = "No records effected";
            }
            return RedirectToAction("Index", new { roleId = roleId });
        }
    
    }
}
