using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class PropertyInformationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyInformationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
