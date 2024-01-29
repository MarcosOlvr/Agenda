using Agenda.Models;

namespace Agenda.Repositories.Contracts
{
    public interface ICompromissoRepository
    {
        List<Compromisso> GetAllCompromissos(int agendaId);  
        Compromisso GetCompromisso(int id);
        void DeleteCompromisso(int id);
        void UpdateCompromisso(Compromisso obj);
        void AddCompromisso(Compromisso obj);
    }
}
