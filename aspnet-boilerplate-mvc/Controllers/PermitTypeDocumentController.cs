using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class PermitTypeDocumentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermitTypeDocumentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<PermitTypeDocument> permitTypeDocuments = _unitOfWork.permitTypeDocumentRepository.GetAll();
            return View(permitTypeDocuments);
        }

        public IActionResult Create()
        {
            
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();
            ViewBag.PermitTypes = _unitOfWork.permitTypeRepository.GetAll();
            ViewBag.PermitCategories = _unitOfWork.permitCategoryRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(PermitTypeDocument permitTypeDocument)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.permitTypeDocumentRepository.Add(permitTypeDocument);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

           
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();
            ViewBag.PermitTypes = _unitOfWork.permitTypeRepository.GetAll();
            ViewBag.PermitCategories = _unitOfWork.permitCategoryRepository.GetAll();

            return View(permitTypeDocument);
        }

        public IActionResult Edit(int id)
        {
            PermitTypeDocument permitTypeDocument = _unitOfWork.permitTypeDocumentRepository.GetOne(q => q.Id == id);
            if (permitTypeDocument == null)
            {
                return NotFound();
            }

            
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();
            ViewBag.PermitTypes = _unitOfWork.permitTypeRepository.GetAll();
            ViewBag.PermitCategories = _unitOfWork.permitCategoryRepository.GetAll();

            return View(permitTypeDocument);
        }

        [HttpPost]
        public IActionResult Edit(PermitTypeDocument permitTypeDocument)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.permitTypeDocumentRepository.Update(permitTypeDocument);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            ///  the documents, permit types, and permit categories dropdown lists needs to be populated
            ViewBag.Documents = _unitOfWork.documentRepository.GetAll();
            ViewBag.PermitTypes = _unitOfWork.permitTypeRepository.GetAll();
            ViewBag.PermitCategories = _unitOfWork.permitCategoryRepository.GetAll();

            return View(permitTypeDocument);
        }

        public IActionResult Delete(int id)
        {
            PermitTypeDocument permitTypeDocument = _unitOfWork.permitTypeDocumentRepository.GetOne(q=>q.Id == id);
            if (permitTypeDocument == null)
            {
                return NotFound();
            }

            return View(permitTypeDocument);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            PermitTypeDocument permitTypeDocument = _unitOfWork.permitTypeDocumentRepository.GetOne(q=>q.Id == id);
            if (permitTypeDocument == null)
            {
                return NotFound();
            }

            _unitOfWork.permitTypeDocumentRepository.Remove(permitTypeDocument);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
