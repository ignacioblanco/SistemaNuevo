using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Sistema.lib.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
            Database.SetInitializer<DatabaseContext>(null);
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 1000;
        }


        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
        public DbSet<OpcionPerfil> OpcionesPerfiles { get; set; }

    }
}
