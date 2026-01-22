using GestionEmpleadosAPI.Data;
using GestionEmpleadosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpleadosAPI.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> ObtenerTodos()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> ObtenerPorId(int id)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Empleado> Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<Empleado?> Actualizar(Empleado empleado)
        {
            var existente = await _context.Empleados.FirstOrDefaultAsync(e => e.Id == empleado.Id);
            if (existente == null) return null;

            existente.NombreCompleto = empleado.NombreCompleto;
            existente.Cargo = empleado.Cargo;
            existente.Salario = empleado.Salario;
            existente.FechaContrato = empleado.FechaContrato;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> Eliminar(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}