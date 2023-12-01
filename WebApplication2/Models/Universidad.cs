using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsUniversidad
{
    public class Universidad
    {
        [Key]
        public int idUniversidad { get; set; }
        public string? Nombre { get; set; }
   
    }
}