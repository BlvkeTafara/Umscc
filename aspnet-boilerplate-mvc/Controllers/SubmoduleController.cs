using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    [Authorize(Roles = "Submodule.Index")]
    public class SubmoduleController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public SubmoduleController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index(int id)
        {
            var module = _unitofwork.moduleRepository.GetOne(q=>q.Id==id,new List<string> { "submodules"});
            return View(module);
        }
        [Authorize(Roles = "Submodule.Add")]
        [HttpGet, ActionName("Modify")]
        public IActionResult Modify(int? id,int moduleId)
        {
           Submodule submodule = new Submodule() { ModuleId=moduleId};
            if (id.HasValue)
            {
                submodule = _unitofwork.submoduleRepository.GetOne(q => q.Id == id);
            }
            return View(submodule);
        }
        [Authorize(Roles = "Submodule.Add")]
        [HttpPost, ActionName("Modify")]
        public async Task<IActionResult> Modify(Submodule obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitofwork.submoduleRepository.Add(new Submodule { Name = obj.Name,ModuleId=obj.ModuleId, Icon = obj.Icon,Controller=obj.Controller, DefaultAction = obj.DefaultAction });
                }
                else
                {
                    _unitofwork.submoduleRepository.Update(obj);
                }
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    TempData["success"] = "Module successfully modified";
                }
                else
                {
                    TempData["error"] = "An error has occured";
                }
                return RedirectToAction("Index",new {id=obj.ModuleId});
            }
            return View(obj);

        }
        [Authorize(Roles = "Submodule.Delete")]
        [HttpGet, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var record = _unitofwork.submoduleRepository.GetOne(q => q.Id == id);
            return View(record);
        }
        [Authorize(Roles = "Submodule.Delete")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Submodule obj)
        {
            _unitofwork.submoduleRepository.Remove(obj);
            var id = obj.ModuleId;
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                TempData["success"] = "Record successfully deleted";
            }
            else
            {
                TempData["error"] = "An error has occured";
            }
            return RedirectToAction("Index", new { id = id});
        }
    }
}
