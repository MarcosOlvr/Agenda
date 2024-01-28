using Agenda.Data;
using Agenda.Models;
using Agenda.Repositories.Contracts;

namespace Agenda.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly ApplicationDbContext _context;

        public AgendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAgenda(Agendas obj)
        {
            _context.Agendas.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteAgenda(int id)
        {
            _context.Agendas.Remove(GetAgenda(id));
            _context.SaveChanges();
        }

        public Agendas GetAgenda(int id)
        {
            return _context.Agendas.FirstOrDefault(x => x.Id == id);
        }

        public List<Agendas> GetAllAgendas(string userName)
        {
            return _context.Agendas.Where(x => x.User == userName).ToList();
        }

        public void UpdateAgenda(Agendas obj)
        {
            var agenda = _context.Agendas.Find(obj.Id);

            if (agenda != null)
            {
                agenda.Name = obj.Name;

                _context.Update(agenda);
                _context.SaveChanges();
            }
        }
    }
}
