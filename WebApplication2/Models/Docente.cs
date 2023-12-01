using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsDocente
{
    public class Docente
    {
        [Key]
        public int idDocente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Asignatura { get; set; }
        public int idUniversidad { get; set; }
    }
}