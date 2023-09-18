using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_boilerplate_mvc.Controllers
{
    public class RainmonitorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RainmonitorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
