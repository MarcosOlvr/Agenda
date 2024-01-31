using Agenda.Models;
using Agenda.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [Authorize]
    public class CompromissoController : Controller
    {
        private readonly ICompromissoRepository _comRepo;

        public CompromissoController(ICompromissoRepository comRepo)
        {
            _comRepo = comRepo;
        }

        public IActionResult Index(int agendaId)
        {
            var compromissos = _comRepo.GetAllCompromissos(agendaId);

            TempData["agendaId"] = agendaId;

            return View(compromissos);
        }

        [HttpGet]
        public IActionResult CreateCompromisso(int agendaId)
        {
            var compromisso = new Compromisso();

            compromisso.AgendaId = agendaId;

            TempData["agendaId"] = agendaId;

            return View(compromisso);
        }

        [HttpPost]
        public IActionResult CreateCompromisso(Compromisso obj)
        {
            if (ModelState.IsValid)
            {
                _comRepo.AddCompromisso(obj);

                return RedirectToAction("Index", new { agendaId = TempData["agendaId"] });
            }
            
            return View(obj);
        }

        [HttpGet]
        public IActionResult EditCompromisso(int compromissoId)
        {
            var compromisso = _comRepo.GetCompromisso(compromissoId);

            TempData["agendaId"] = compromisso.AgendaId;

            if (compromisso != null)
                return View(compromisso);

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditCompromisso(Compromisso obj)
        {
            if (ModelState.IsValid)
            {
                _comRepo.UpdateCompromisso(obj);

                return RedirectToAction("Index", new { agendaId = TempData["agendaId"] });
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult DeleteCompromisso(int compromissoId)
        {
            var compromisso = _comRepo.GetCompromisso(compromissoId);

            TempData["agendaId"] = compromisso.AgendaId;

            if (compromisso != null)
                return View(compromisso);
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteCompromisso(Compromisso obj)
        {
            _comRepo.DeleteCompromisso(obj.Id);

            return RedirectToAction("Index", new { agendaId = TempData["agendaId"] });
        }
    }
}
