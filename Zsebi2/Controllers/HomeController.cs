using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zsebi2.Models;
using Zsebi2.Services;

namespace Zsebi2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamService _teamService;

        public HomeController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new MainViewModel
            {
                Team = await _teamService.GetTeamViewModel()
            };

            return View(model);
        }

        public IActionResult RadioDetails()
        {
            return PartialView("_RadioDetails");
        }
        public IActionResult ContactTeam()
        {
            return PartialView("_ContactTeam");
        }
        public IActionResult SatelliteEngineering()
        {
            return PartialView("_SatelliteEngineering");
        }

        public IActionResult TechnicalInfo()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
