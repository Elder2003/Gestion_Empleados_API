using System.ComponentModel.DataAnnotations;

namespace GestionEmpleadosAPI.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public DateTime FechaContrato { get; set; }
    }
}