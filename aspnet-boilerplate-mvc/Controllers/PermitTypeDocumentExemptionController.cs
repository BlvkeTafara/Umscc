using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class PermitTypeDocumentExemptionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermitTypeDocumentExemptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<PermitTypeDocumentExemption> exemptions = _unitOfWork.permitTypeDocumentExemptionRepository.GetAll();
            return View(exemptions);
        }

        public IActionResult Create()
        {
            /// the permit type documents and purposes dropdown lists need to be ppopulated
            ViewBag.PermitTypeDocuments = _unitOfWork.permitTypeDocumentRepository.GetAll();
            ViewBag.Purposes = _unitOfWork.purposeRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(PermitTypeDocumentExemption exemption)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.permitTypeDocumentExemptionRepository.Add(exemption);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            ViewBag.PermitTypeDocuments = _unitOfWork.permitTypeDocumentRepository.GetAll();
            ViewBag.Purposes = _unitOfWork.purposeRepository.GetAll();

            return View(exemption);
        }

        public IActionResult Edit(int id)
        {
            PermitTypeDocumentExemption exemption = _unitOfWork.permitTypeDocumentExemptionRepository.GetOne(q => q.Id == id);
            if (exemption == null)
            {
                return NotFound();
            }

            
            ViewBag.PermitTypeDocuments = _unitOfWork.permitTypeDocumentRepository.GetAll();
            ViewBag.Purposes = _unitOfWork.purposeRepository.GetAll();

            return View(exemption);
        }

        [HttpPost]
        public IActionResult Edit(PermitTypeDocumentExemption exemption)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.permitTypeDocumentExemptionRepository.Update(exemption);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            
            ViewBag.PermitTypeDocuments = _unitOfWork.permitTypeDocumentRepository.GetAll();
            ViewBag.Purposes = _unitOfWork.purposeRepository.GetAll();

            return View(exemption);
        }

        public IActionResult Delete(int id)
        {
            PermitTypeDocumentExemption exemption = _unitOfWork.permitTypeDocumentExemptionRepository.GetOne(q=>q.Id== id);
            if (exemption == null)
            {
                return NotFound();
            }

            return View(exemption);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            PermitTypeDocumentExemption exemption = _unitOfWork.permitTypeDocumentExemptionRepository.GetOne(q => q.Id == id);
            if (exemption == null)
            {
                return NotFound();
            }

            _unitOfWork.permitTypeDocumentExemptionRepository.Remove(exemption);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
