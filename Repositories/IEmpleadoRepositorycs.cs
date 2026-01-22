using GestionEmpleadosAPI.Models;

namespace GestionEmpleadosAPI.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> ObtenerTodos();
        Task<Empleado?> ObtenerPorId(int id);
        Task<Empleado> Agregar(Empleado empleado);
        Task<Empleado?> Actualizar(Empleado empleado);
        Task<bool> Eliminar(int id);
    }
}