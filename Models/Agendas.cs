using Microsoft.AspNetCore.Identity;

namespace Agenda.Models
{
    public class Agendas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
    }
}
