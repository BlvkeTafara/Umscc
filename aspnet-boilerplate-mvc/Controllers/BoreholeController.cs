using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class BoreholeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BoreholeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public IActionResult Index()
        {
            var boreholes = _unitOfWork.boreholeRepository.GetAll();
            return View(boreholes);
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borehole =  _unitOfWork.boreholeRepository.GetOne(q=>q.Id == id);

            if (borehole == null)
            {
                return NotFound();
            }

            return View(borehole);
        }

       
        public IActionResult Create()
        {
            PopulateDropdownLists();
            return View();
        }

       
        public IActionResult Create(Borehole borehole)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.boreholeRepository.Add(borehole);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            PopulateDropdownLists();
            return View(borehole);
        }

       
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borehole = _unitOfWork.boreholeRepository.GetOne(q => q.Id == id);

            if (borehole == null)
            {
                return NotFound();
            }

            PopulateDropdownLists();
            return View(borehole);
        }

        [HttpPost]
        public IActionResult Edit(int id, Borehole borehole)
        {
            if (id != borehole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.boreholeRepository.Update(borehole);
                     _unitOfWork.Save();
                }
                catch
                {
                    if (!_unitOfWork.boreholeRepository.Exists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateDropdownLists();
            return View(borehole);
        }

       
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borehole = _unitOfWork.boreholeRepository.GetOne(q=>q.Id == id);

            if (borehole == null)
            {
                return NotFound();
            }

            return View(borehole);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.boreholeRepository.Remove(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropdownLists()
        {
            ViewBag.PurposeId = _unitOfWork.purposeRepository.GetAll(); 
            ViewBag.PropertyInformationId = _unitOfWork.propertyInformationRepository.GetAll(); 
        }
    }
}
