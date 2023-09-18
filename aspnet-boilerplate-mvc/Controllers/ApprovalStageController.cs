using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class ApprovalStageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApprovalStageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var approvalStages = _unitOfWork.approvalStageRepository.GetAll();
            return View(approvalStages);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var approvalStage = _unitOfWork.approvalStageRepository.GetOne(q=>q.Id == id );
            if (approvalStage == null)
            {
                return NotFound();
            }
            else
            {
                return View(approvalStage);
            }
            return View(approvalStage);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ApprovalStage approvalStage)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.approvalStageRepository.Create(approvalStage);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(approvalStage);
        }
        [HttpPost]
        public ActionResult Edit(ApprovalStage approvalStage)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.approvalStageRepository.Update(approvalStage);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(approvalStage);
        }
        [HttpDelete, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var approvalStage = _unitOfWork.approvalStageRepository.GetOne(q=>q.Id == id);
            if (approvalStage == null)
            {
                return NotFound();
            }
            return View(approvalStage);
        }

        


    }
}
