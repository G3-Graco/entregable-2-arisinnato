using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _ubicacionService;

        // Inyectar el servicio en el constructor
        public UbicacionController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Ubicacion>> Get()
        {
            return Ok(_ubicacionService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Ubicacion> Get(int id)
        {
            var ubicacion = _ubicacionService.GetById(id);
            if (ubicacion == null)
            {
                return NotFound();
            }
            return Ok(ubicacion);
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] Ubicacion ubicacion)
        {
            _ubicacionService.Add(ubicacion);
            return CreatedAtAction(nameof(Get), new { id = ubicacion.id }, ubicacion);
        }

       
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ubicacion ubicacion)
        {
            _ubicacionService.Update(id, ubicacion);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _ubicacionService.Delete(id);
            return NoContent();
        }
    }
}