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
            //modelBuilder.Entity<Miembro>().HasData(
            //   new Miembro
            //   {
            //       Id = 11,
            //       Nombre = "David",
            //       Apellido = "Gonzales",
            //       DNI = "35.214.872"
            //       Password = "ASD"
            //   },
            //   new Peluquero
            //   {
            //       Id = 23,
            //       Nombre = "Eduardo",
            //       Apellido = "Del Valle",
            //       DNI = "25.214.872",
            //       Password = "ASD"
            //   }
            //);

            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                                       && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}


