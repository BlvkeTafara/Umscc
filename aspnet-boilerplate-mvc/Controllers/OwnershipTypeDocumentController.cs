using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class OwnershipTypeDocumentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnershipTypeDocumentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<OwnershipTypeDocument> ownershipTypeDocuments = _unitOfWork.ownershipTypeDocumentRepository.GetAll();
            return View(ownershipTypeDocuments);
        }

        public IActionResult Create()
        {
            // Populate the ownership types and documents dropdown lists
            ViewBag.OwnershipTypes = _unitOfWork.ownershipTypeRepository.GetAll();
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(OwnershipTypeDocument ownershipTypeDocument)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ownershipTypeDocumentRepository.Add(ownershipTypeDocument);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            // Populate the ownership types and documents dropdown lists
            ViewBag.OwnershipTypes = _unitOfWork.ownershipTypeRepository.GetAll();
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();

            return View(ownershipTypeDocument);
        }

        public IActionResult Edit(int id)
        {
            OwnershipTypeDocument ownershipTypeDocument = _unitOfWork.ownershipTypeDocumentRepository.GetOne(q=>q.Id == id);
            if (ownershipTypeDocument == null)
            {
                return NotFound();
            }

            // Populate the ownership types and documents dropdown lists
            ViewBag.OwnershipTypes = _unitOfWork.ownershipTypeRepository.GetAll();
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();

            return View(ownershipTypeDocument);
        }

        [HttpPost]
        public IActionResult Edit(OwnershipTypeDocument ownershipTypeDocument)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ownershipTypeDocumentRepository.Update(ownershipTypeDocument);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            // Populate the ownership types and documents dropdown lists
            ViewBag.OwnershipTypes = _unitOfWork.ownershipTypeRepository.GetAll();
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();

            return View(ownershipTypeDocument);
        }

        public IActionResult Delete(int id)
        {
            OwnershipTypeDocument ownershipTypeDocument = _unitOfWork.ownershipTypeDocumentRepository.GetOne(q => q.Id == id);
            if (ownershipTypeDocument == null)
            {
                return NotFound();
            }

            return View(ownershipTypeDocument);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            OwnershipTypeDocument ownershipTypeDocument = _unitOfWork.ownershipTypeDocumentRepository.GetOne(q => q.Id == id);
            if (ownershipTypeDocument == null)
            {
                return NotFound();
            }

            _unitOfWork.ownershipTypeDocumentRepository.Remove(ownershipTypeDocument);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
