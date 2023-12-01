using Microsoft.EntityFrameworkCore;
using WebApplication2.ModelsEstudiante;
using WebApplication2.ModelsDocente;
using WebApplication2.ModelsUniversidad;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Universidad> Universidad { get; set; }

    }
}
