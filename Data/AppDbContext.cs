using Microsoft.EntityFrameworkCore;
using CoreGastos.Models; // Asegúrate de que el namespace coincide con tu proyecto.

namespace CoreGastos.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor para configurar el DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet para cada tabla de la base de datos
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
