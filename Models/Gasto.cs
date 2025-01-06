using System.ComponentModel.DataAnnotations.Schema;

namespace CoreGastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        [Column("EmpleadoId")] // Ajusta este nombre según la base de datos
        public int IdEmpleado { get; set; }

        [Column("DepartamentoId")] // Ajusta este nombre según la base de datos
        public int IdDepartamento { get; set; }

        public Empleado Empleado { get; set; }
        public Departamento Departamento { get; set; }
    }
}
