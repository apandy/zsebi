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
            return View("_ThermalCamera");
        }

        public IActionResult ThermalVacuumChamber()
        {
            return View("_ThermalVacuumChamber");
        }

        public IActionResult Shaker()
        {
            return View("_Shaker");
        }

        public IActionResult BalloonFlight()
        {
            return View("_BalloonFlight");
        }
    }
}