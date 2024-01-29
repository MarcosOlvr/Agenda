using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd-MM-yy", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int AgendaId { get; set; }
    }
}
