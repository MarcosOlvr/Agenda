using Agenda.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agendas> Agendas { get; set; }
        public DbSet<Compromisso> Compromissos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Agendas>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Compromisso>()
                .HasOne<Agendas>()
                .WithMany()
                .HasForeignKey(t => t.AgendaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}