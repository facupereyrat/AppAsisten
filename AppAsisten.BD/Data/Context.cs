using AppAsisten.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppAsisten.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para las relaciones y las claves foráneas
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Miembro y Asistencia
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Miembro)  // Cada Asistencia tiene un Miembro
                .WithMany(m => m.Asistencias)  // Cada Miembro puede tener muchas Asistencias
                .HasForeignKey(a => a.MiembroId);  // Clave foránea MiembroId
        }
    }
}

