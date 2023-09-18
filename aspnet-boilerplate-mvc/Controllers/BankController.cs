using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class BankController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Bank
        public  IActionResult Index()
        {
            List<Bank> banks = _unitOfWork.bankRepository.GetAll().ToList();
            return View(banks);
        }

        
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bank bank = _unitOfWork.bankRepository.GetOne(q=>q.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public  IActionResult Create([Bind("Id,Name,Status")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.bankRepository.Add(bank);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(bank);
        }

        
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bank bank =  _unitOfWork.bankRepository.GetOne(q=>q.Id == id);
            if (bank == null)
            {
                return NotFound();
            }
            return View(bank);
        }

        
        [HttpPost]
        public  IActionResult Edit(int id, [Bind("Id,Name,Status")] Bank bank)
        {
            if (id != bank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.bankRepository.Update(bank);
                    _unitOfWork.Save();
                }
                catch
                {
                    if (!_unitOfWork.bankRepository.Exists(id))
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
            return View(bank);
        }

       
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bank bank = _unitOfWork.bankRepository.GetOne(q=>q.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Bank bank =  _unitOfWork.bankRepository.GetOne(q=>q.Id == id);
            _unitOfWork.bankRepository.Remove(bank);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}