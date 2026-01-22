using GestionEmpleadosAPI.Models;
using GestionEmpleadosAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GestionEmpleadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _repository;
        public EmpleadoController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var empleados = await _repository.ObtenerTodos();
            return Ok(empleados);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var empleado = await _repository.ObtenerPorId(id);
            if (empleado == null) return NotFound("Empleado no encontrado");
            return Ok(empleado);
        }
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Empleado empleado)
        {
            if (empleado == null) return BadRequest();
            empleado.Id = 0;

            var nuevoEmpleado = await _repository.Agregar(empleado);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo");

            var actualizado = await _repository.Actualizar(empleado);
            if (actualizado == null) return NotFound("Empleado no existe");

            return Ok(actualizado);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _repository.Eliminar(id);
            if (!eliminado) return NotFound("No se pudo eliminar");
            return NoContent();
        }
    }
}