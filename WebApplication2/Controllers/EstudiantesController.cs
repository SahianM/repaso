using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsEstudiante;  // Cambiar el nombre del espacio de nombres

namespace WebApplication2.ControllersEstudiante  // Cambiar el nombre del controlador
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase  // Cambiar el nombre del controlador
    {
        private readonly ILogger<EstudianteController> _logger;  // Cambiar el nombre del controlador
        private readonly AplicacionContexto _aplicacionContexto;

        public EstudianteController(
            ILogger<EstudianteController> logger,  // Cambiar el nombre del controlador
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear estudiante
        [HttpPost(Name = "PostEstudiante")]  // Cambiar el nombre de la acción
        public IActionResult Post([FromBody] Estudiante estudiante)  // Cambiar el nombre del modelo
        {
            _aplicacionContexto.Estudiante.Add(estudiante);  // Cambiar el nombre del modelo
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);  // Cambiar el nombre del modelo
        }

        // Read: Obtener lista de estudiantes
        [HttpGet(Name = "GetEstudiante")]  // Cambiar el nombre de la acción
        public IEnumerable<Estudiante> Get()  // Cambiar el nombre del modelo
        {
            return _aplicacionContexto.Estudiante.ToList();  // Cambiar el nombre del modelo
        }

        // Update: Modificar estudiante
        [HttpPut(Name = "PutEstudiante")]  // Cambiar el nombre de la acción
        public IActionResult Put([FromBody] Estudiante estudiante)  // Cambiar el nombre del modelo
        {
            _aplicacionContexto.Estudiante.Update(estudiante);  // Cambiar el nombre del modelo
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);  // Cambiar el nombre del modelo
        }

        // Delete: Eliminar estudiante
        [HttpDelete(Name = "DeleteEstudiante")]  // Cambiar el nombre de la acción
        public IActionResult Delete(int estudianteId)  // Cambiar el nombre del modelo
        {
            var estudianteToDelete = _aplicacionContexto.Estudiante
                .FirstOrDefault(x => x.idEstudiante == estudianteId);  // Cambiar el nombre del modelo

            if (estudianteToDelete != null)
            {
                _aplicacionContexto.Estudiante.Remove(estudianteToDelete);  // Cambiar el nombre del modelo
                _aplicacionContexto.SaveChanges();
                return Ok(estudianteId);  // Cambiar el nombre del modelo
            }
            else
            {
                return NotFound($"Estudiante con Id {estudianteId} no encontrado.");  // Cambiar el nombre del modelo
            }
        }
    }
}
