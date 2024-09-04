using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
