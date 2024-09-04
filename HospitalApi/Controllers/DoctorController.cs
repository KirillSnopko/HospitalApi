using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
