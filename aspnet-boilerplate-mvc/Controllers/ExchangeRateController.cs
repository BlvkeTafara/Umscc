using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class ExchangeRateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeRateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<ExchangeRate> exchangeRates = _unitOfWork.exchangeRateRepository.GetAll();
            return View(exchangeRates);
        }

        public IActionResult Create()
        {
            
            ViewBag.PrimaryCurrencies = _unitOfWork.currencyRepository.GetAll();
            ViewBag.SecondaryCurrencies = _unitOfWork.currencyRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.exchangeRateRepository.Add(exchangeRate);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            
            ViewBag.PrimaryCurrencies = _unitOfWork.currencyRepository.GetAll();
            ViewBag.SecondaryCurrencies = _unitOfWork.currencyRepository.GetAll();

            return View(exchangeRate);
        }

        public IActionResult Edit(int id)
        {
            ExchangeRate exchangeRate = _unitOfWork.exchangeRateRepository.GetOne(q=>q.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            /// the primary and secondary currencies dropdown lists needs to be populated
            ViewBag.PrimaryCurrencies = _unitOfWork.currencyRepository.GetAll();
            ViewBag.SecondaryCurrencies = _unitOfWork.currencyRepository.GetAll();

            return View(exchangeRate);
        }

        [HttpPost]
        public IActionResult Edit(ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.exchangeRateRepository.Update(exchangeRate);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            // Populate the primary and secondary currencies dropdown lists
            ViewBag.PrimaryCurrencies = _unitOfWork.currencyRepository.GetAll();
            ViewBag.SecondaryCurrencies = _unitOfWork.currencyRepository.GetAll();

            return View(exchangeRate);
        }

        public IActionResult Delete(int id)
        {
            ExchangeRate exchangeRate = _unitOfWork.exchangeRateRepository.GetOne(q => q.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            ExchangeRate exchangeRate = _unitOfWork.exchangeRateRepository.GetOne(q => q.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            _unitOfWork.exchangeRateRepository.Remove(exchangeRate);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
