using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsDocente;  // Cambiar el nombre del espacio de nombres

namespace WebApplication2.ControllersDocente  // Cambiar el nombre del controlador
{
    [ApiController]
    [Route("[controller]")]
    public class DocenteController : ControllerBase  // Cambiar el nombre del controlador
    {
        private readonly ILogger<DocenteController> _logger;  // Cambiar el nombre del controlador
        private readonly AplicacionContexto _aplicacionContexto;

        public DocenteController(
            ILogger<DocenteController> logger,  // Cambiar el nombre del controlador
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear docente
        [HttpPost(Name = "PostDocente")]  // Cambiar el nombre de la acción
        public IActionResult Post([FromBody] Docente docente)  // Cambiar el nombre del modelo
        {
            _aplicacionContexto.Docente.Add(docente);  // Cambiar el nombre del modelo
            _aplicacionContexto.SaveChanges();
            return Ok(docente);  // Cambiar el nombre del modelo
        }

        // Read: Obtener lista de docentes
        [HttpGet(Name = "GetDocente")]  // Cambiar el nombre de la acción
        public IEnumerable<Docente> Get()  // Cambiar el nombre del modelo
        {
            return _aplicacionContexto.Docente.ToList();  // Cambiar el nombre del modelo
        }

        // Update: Modificar docente
        [HttpPut(Name = "PutDocente")]  // Cambiar el nombre de la acción
        public IActionResult Put([FromBody] Docente docente)  // Cambiar el nombre del modelo
        {
            _aplicacionContexto.Docente.Update(docente);  // Cambiar el nombre del modelo
            _aplicacionContexto.SaveChanges();
            return Ok(docente);  // Cambiar el nombre del modelo
        }

        // Delete: Eliminar docente
        [HttpDelete(Name = "DeleteDocente")]  // Cambiar el nombre de la acción
        public IActionResult Delete(int docenteId)  // Cambiar el nombre del modelo
        {
            var docenteToDelete = _aplicacionContexto.Docente
                .FirstOrDefault(x => x.idDocente == docenteId);  // Cambiar el nombre del modelo

            if (docenteToDelete != null)
            {
                _aplicacionContexto.Docente.Remove(docenteToDelete);  // Cambiar el nombre del modelo
                _aplicacionContexto.SaveChanges();
                return Ok(docenteId);  // Cambiar el nombre del modelo
            }
            else
            {
                return NotFound($"Docente con Id {docenteId} no encontrada.");  // Cambiar el nombre del modelo
            }
        }
    }
}
