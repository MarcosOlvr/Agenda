using Agenda.Data;
using Agenda.Models;
using Agenda.Repositories.Contracts;

namespace Agenda.Repositories
{
    public class CompromissoRepository : ICompromissoRepository
    {
        private readonly ApplicationDbContext _context;

        public CompromissoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCompromisso(Compromisso obj)
        {
            _context.Compromissos.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteCompromisso(int id)
        {
            _context.Compromissos.Remove(GetCompromisso(id));
            _context.SaveChanges();
        }

        public List<Compromisso> GetAllCompromissos()
        {
            return _context.Compromissos.ToList();
        }

        public Compromisso GetCompromisso(int id)
        {
            return _context.Compromissos.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCompromisso(Compromisso obj)
        {
            _context.Compromissos.Update(obj);
            _context.SaveChanges();
        }
    }
}
