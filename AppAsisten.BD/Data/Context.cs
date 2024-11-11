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


