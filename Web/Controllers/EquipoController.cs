using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService _equipoService;

        // Inyectar el servicio en el constructor
        public EquipoController(IEquipoService equipoService)
        {
            _equipoService = equipoService;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Equipo>> Get()
        {
            return Ok(_equipoService.GetAll());
        }

       
        [HttpGet("{id}")]
        public ActionResult<Equipo> Get(int id)
        {
            var equipo = _equipoService.GetById(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] Equipo equipo)
        {
            _equipoService.Add(equipo);
            return CreatedAtAction(nameof(Get), new { id = equipo.id }, equipo);
        }

        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Equipo equipo)
        {
            _equipoService.Update(id, equipo);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _equipoService.Delete(id);
            return NoContent();
        }

        // POST: api/Equipo/5/Equipar/casco
        [HttpPost("{id}/Equipar/{tipoObjeto}")]
        public ActionResult Equipar(int id, string tipoObjeto)
        {
            _equipoService.Equipar(id, tipoObjeto);
            return Ok();
        }

        [HttpPost("{id}/Desequipar/{tipoObjeto}")]
        public ActionResult Desequipar(int id, string tipoObjeto)
        {
            _equipoService.Desequipar(id, tipoObjeto);
            return Ok();
        }
    }
}
