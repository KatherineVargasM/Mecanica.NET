using Microsoft.EntityFrameworkCore;

namespace Mecanica.NET
{
    public class AngularDbContext : DbContext
    {
        public AngularDbContext(DbContextOptions op) : base(op)
        {

        }
        public DbSet<empleadoModel> Empleados { get; set; }
        public DbSet<usuarioModel> Usuarios { get; set; }
        public DbSet<vehiculoModel> Vehiculos { get; set; }
        public DbSet<servicioModel> Servicios { get; set; }
    }
}

