using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class PermitTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermitTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<PermitType> permitTypes = _unitOfWork.permitTypeRepository.GetAll();
            return View(permitTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PermitType permitType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.permitTypeRepository.Add(permitType);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(permitType);
        }

        public IActionResult Edit(int id)
        {
            PermitType permitType = _unitOfWork.permitTypeRepository.GetOne(q => q.Id == id);
            if (permitType == null)
            {
                return NotFound();
            }

            return View(permitType);
        }

        [HttpPost]
        public IActionResult Edit(PermitType permitType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.permitTypeRepository.Update(permitType);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(permitType);
        }

        public IActionResult Delete(int id)
        {
            PermitType permitType = _unitOfWork.permitTypeRepository.GetOne(q => q.Id == id);
            if (permitType == null)
            {
                return NotFound();
            }

            return View(permitType);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            PermitType permitType = _unitOfWork.permitTypeRepository.GetOne(q => q.Id == id);
            if (permitType == null)
            {
                return NotFound();
            }

            _unitOfWork.permitTypeRepository.Remove(permitType);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
