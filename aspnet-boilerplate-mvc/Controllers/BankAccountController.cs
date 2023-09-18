using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Models;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankAccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var bankAccounts = _unitOfWork.bankAccountRepository.GetAll().ToList();
            return View(bankAccounts);
        }

        [HttpPost]
        public IActionResult Create(BankAccount model)
        {
            if (ModelState.IsValid)
            {
                var bankAccount = new BankAccount
                {
                    AccountNumber = model.AccountNumber,
                    BankId = model.BankId,
                    CurrencyId = model.CurrencyId,
                    Type = model.Type,
                    Status = model.Status
                };

                _unitOfWork.bankAccountRepository.Add(bankAccount);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public  IActionResult Edit(int id, BankAccountModel model)
        {
            var bankAccount =  _unitOfWork.bankAccountRepository.GetOne(q=>q.Id == id);
            if (id != model.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var BankAccount =  _unitOfWork.bankAccountRepository.GetOne(q=>q.Id==id);
                if (bankAccount == null)
                {
                    return NotFound();
                }

                bankAccount.AccountNumber = model.AccountNumber;
                bankAccount.BankId = model.BankId;
                bankAccount.CurrencyId = model.CurrencyId;
                bankAccount.Type = model.Type;
                bankAccount.Status = model.Status;

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var bankAccount =  _unitOfWork.bankAccountRepository.GetOne(q=>q.Id == id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }
    }
}

