using Agenda.Models;
using Agenda.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        private readonly IAgendaRepository _agendaRepo;

        public AgendaController(IAgendaRepository agendaRepository) 
        {
            _agendaRepo = agendaRepository;
        }

        public IActionResult Index()
        {
            var agendas = _agendaRepo.GetAllAgendas(User.Identity.Name);

            return View(agendas);
        }

        [HttpGet]
        public IActionResult CreateAgenda()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAgenda(Agendas obj)
        {
            if (ModelState.IsValid)
            {
                _agendaRepo.AddAgenda(obj);

                return RedirectToAction("Index");
            }
            
            return View(obj);
        }

        [HttpGet]
        public IActionResult EditAgenda(int agendaId)
        {
            var agenda = _agendaRepo.GetAgenda(agendaId);

            if (agenda == null)
                return NotFound();

            return View(agenda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAgenda(Agendas obj)
        {
            if (ModelState.IsValid)
            {
                _agendaRepo.UpdateAgenda(obj);

                return RedirectToAction("Index");
            }

            return View(obj);   
        }

        [HttpGet]
        public IActionResult DeleteAgenda(int agendaId)
        {
            var agenda = _agendaRepo.GetAgenda(agendaId);

            if (agenda == null) 
                return NotFound();

            return View(agenda);
        }

        [HttpPost]
        public IActionResult DeleteAgenda(Agendas obj)
        {
            _agendaRepo.DeleteAgenda(obj.Id);

            return RedirectToAction("Index");
        }
    }
}