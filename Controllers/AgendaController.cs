using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAgenda()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditAgenda()
        {
            return View();
        }
    }
}
