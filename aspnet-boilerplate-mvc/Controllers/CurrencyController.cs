using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public CurrencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
        {
            var currencies = _unitOfWork.currencyRepository.GetAll();
            return View(currencies);
        }
        
        [HttpPost]
        public IActionResult Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.currencyRepository.Add(currency);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        
        [HttpPost]
        
        public IActionResult Edit(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.currencyRepository.BulkUpdate(currency);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(currency);
            }

           
        }

        [HttpPost]
        
        public IActionResult DeleteConfirmed(int id)
        {
            var currency = _unitOfWork.currencyRepository.GetOne(q=>q.Id == id);
            if (currency == null)
            {
                return NotFound();
            }

            _unitOfWork.currencyRepository.Remove(currency);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }

}

