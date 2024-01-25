using Agenda.Models;

namespace Agenda.Repositories.Contracts
{
    public interface IAgendaRepository
    {
        List<Agendas> GetAllAgendas(string userName);
        Agendas GetAgenda(int id);
        void AddAgenda(Agendas obj);
        void UpdateAgenda(Agendas obj);
        void DeleteAgenda(int id);
    }
}
