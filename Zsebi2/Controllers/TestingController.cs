using Microsoft.AspNetCore.Mvc;

namespace Zsebi2.Controllers
{
    public class TestingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ThermalCamera()
        {
            return PartialView("_ThermalCamera");
        }

        public IActionResult ThermalVacuumChamber()
        {
            return PartialView("_ThermalVacuumChamber");
        }

        public IActionResult Shaker()
        {
            return PartialView("_Shaker");
        }

        public IActionResult BalloonFlight()
        {
            return PartialView("_BalloonFlight");
        }
    }
}