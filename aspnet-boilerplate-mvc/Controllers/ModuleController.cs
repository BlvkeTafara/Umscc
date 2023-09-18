using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    [Authorize(Roles = "Submodule.Index")]
    public class ModuleController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public ModuleController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            var modules = _unitofwork.moduleRepository.GetAll();
            return View(modules);
        }
        [Authorize(Roles = "Submodule.Add")]
        [HttpGet,ActionName("Modify")]
        public IActionResult Modify(int? id) {
            Module module = new Module();
            if(id.HasValue)
            {
                module = _unitofwork.moduleRepository.GetOne(q=>q.Id == id);
            }
         return View(module);
        }
        [Authorize(Roles = "Submodule.Add")]
        [HttpPost,ActionName("Modify")]
        public async Task<IActionResult> Modify(Module obj) {
            if (ModelState.IsValid) {
                if (obj.Id == 0)
                {
                    _unitofwork.moduleRepository.Add(new Module { Name=obj.Name,Icon=obj.Icon,DefaultAction=obj.DefaultAction});
                }
                else
                {
                    _unitofwork.moduleRepository.Update(obj);
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
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        [Authorize(Roles = "Submodule.Delete")]
        [HttpGet, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var record = _unitofwork.moduleRepository.GetOne(q=>q.Id == id);
            return View(record);
        }
        [Authorize(Roles = "Submodule.Delete")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Module obj)
        {
            _unitofwork.moduleRepository.Remove(obj);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                TempData["success"] = "Record successfully deleted";
            }
            else
            {
                TempData["error"] = "An error has occured";
            }
            return RedirectToAction("Index");
        }
    }
}
