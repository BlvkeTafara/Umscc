using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class OwnershipTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnershipTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<OwnershipType> ownershipTypes = _unitOfWork.ownershipTypeRepository.GetAll();
            return View(ownershipTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OwnershipType ownershipType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ownershipTypeRepository.Add(ownershipType);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(ownershipType);
        }

        public IActionResult Edit(int id)
        {
            OwnershipType ownershipType = _unitOfWork.ownershipTypeRepository.GetOne(q=>q.Id == id);
            if (ownershipType == null)
            {
                return NotFound();
            }

            return View(ownershipType);
        }

        [HttpPost]
        public IActionResult Edit(OwnershipType ownershipType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ownershipTypeRepository.Update(ownershipType);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(ownershipType);
        }

        public IActionResult Delete(int id)
        {
            OwnershipType ownershipType = _unitOfWork.ownershipTypeRepository.GetOne(q=>q.Id == id);
            if (ownershipType == null)
            {
                return NotFound();
            }

            return View(ownershipType);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            OwnershipType ownershipType = _unitOfWork.ownershipTypeRepository.GetOne(q=>q.Id == id);
            if (ownershipType == null)
            {
                return NotFound();
            }

            _unitOfWork.ownershipTypeRepository.Remove(ownershipType);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}