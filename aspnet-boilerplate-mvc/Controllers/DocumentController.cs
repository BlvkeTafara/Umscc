using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Document> documents = _unitOfWork.documentRepository.GetAll();
            return View(documents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.documentRepository.Add(document);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(document);
        }

        public IActionResult Edit(int id)
        {
            Document document = _unitOfWork.documentRepository.GetOne(q=>q.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        [HttpPost]
        public IActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.documentRepository.Update(document);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(document);
        }

        public IActionResult Delete(int id)
        {
            Document document = _unitOfWork.documentRepository.GetOne(q => q.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Document document = _unitOfWork.documentRepository.GetOne(q => q.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            _unitOfWork.documentRepository.Remove(document);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
    

