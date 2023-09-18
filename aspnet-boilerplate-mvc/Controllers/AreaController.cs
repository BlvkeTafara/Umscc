using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class AreaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AreaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var areas = _unitOfWork.areaRepository.GetAll();
            return View(areas);
        }
        public IActionResult Details(int id)
        {
            var area = _unitOfWork.areaRepository.GetOne(q => q.Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }
        [HttpPost]
        public IActionResult Edit(Area area)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.areaRepository.Update(area);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(area);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var area = _unitOfWork.areaRepository.GetOne(q => q.Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var area = _unitOfWork.areaRepository.GetOne(q => q.Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

    }
}
