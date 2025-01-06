using CoreGastos.Data;
using CoreGastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GastosController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint para filtrar gastos por rango de fechas
        [HttpGet("filtrar")]
        public async Task<ActionResult<IEnumerable<object>>> FiltrarGastos([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            // Validar las fechas
            if (fechaInicio > fechaFin)
            {
                return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }

            // Consulta para agrupar gastos por departamento y calcular totales
            var resultados = await _context.Gastos
                .Where(g => g.Fecha >= fechaInicio && g.Fecha <= fechaFin)
                .GroupBy(g => g.IdDepartamento)
                .Select(grupo => new
                {
                    Departamento = _context.Departamentos.FirstOrDefault(d => d.Id == grupo.Key).Nombre,
                    Total = grupo.Sum(g => g.Monto)
                })
                .ToListAsync();

            return Ok(resultados);
        }
    }
}
