using AppAsisten.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAsisten.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<Administrador>()
                .Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Miembro>()
                .Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(40);

            base.OnModelCreating(modelBuilder);
        }
    }
}
