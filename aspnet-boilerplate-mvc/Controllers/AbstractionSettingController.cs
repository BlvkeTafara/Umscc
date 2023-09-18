using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class AbstractionSettingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AbstractionSettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public IActionResult Index()
        {
            var abstractionSettings = _unitOfWork.abstractionSettingRepository.GetAll().ToList();
            return View(abstractionSettings);
        }

        
        public IActionResult Details(int id)
        {
            var abstractionSetting = _unitOfWork.abstractionSettingRepository.GetOne(q => q.Id == id);
            if (abstractionSetting == null)
            {
                return NotFound();
            }

            return View(abstractionSetting);
        }

       
        public IActionResult Create()
        {
           
            var permitTypes = _unitOfWork.permitTypeRepository.GetAll().ToList();
            var purposes = _unitOfWork.purposeRepository.GetAll().ToList();
            var uoms = _unitOfWork.uomRepository.GetAll().ToList();

            var permitTypesSelectList = new SelectList(permitTypes, "Id", "Name");
            var purposesSelectList = new SelectList(purposes, "Id", "Name");
            var uomsSelectList = new SelectList(uoms, "Id", "Name");

            ViewBag.PermitTypes = permitTypesSelectList;
            ViewBag.Purposes = purposesSelectList;
            ViewBag.Uoms = uomsSelectList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(AbstractionSetting abstractionSetting)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.abstractionSettingRepository.Add(abstractionSetting);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(abstractionSetting);
        }

       
        public IActionResult Edit(int id)
        {
            var abstractionSetting = _unitOfWork.abstractionSettingRepository.GetOne(q => q.Id == id);
            if (abstractionSetting == null)
            {
                return NotFound();
            }

            return View(abstractionSetting);
        }

        
        [HttpPost]
       
        public IActionResult Edit(int id, AbstractionSetting abstractionSetting)
        {
            if (id != abstractionSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.abstractionSettingRepository.Update(abstractionSetting);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(abstractionSetting);
        }

        
        public IActionResult Delete(int id)
        {
            var abstractionSetting = _unitOfWork.abstractionSettingRepository.GetOne(q => q.Id == id);
            if (abstractionSetting == null)
            {
                return NotFound();
            }

            return View(abstractionSetting);
        }

        
        [HttpPost, ActionName("Delete")]
       
        public IActionResult DeleteConfirmed(int id)
        {
            var abstractionSetting = _unitOfWork.abstractionSettingRepository.GetOne(q => q.Id == id);
            if (abstractionSetting == null)
            {
                return NotFound();
            }

            _unitOfWork.abstractionSettingRepository.Remove(abstractionSetting);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
    

