using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MisionController : ControllerBase
    {
        private readonly IMisionService _misionService;

        // Inyectar el servicio en el constructor
        public MisionController(IMisionService misionService)
        {
            _misionService = misionService;
        }

     
        [HttpGet]
        public ActionResult<IEnumerable<Mision>> Get()
        {
            return Ok(_misionService.GetAll());
        }

        
        [HttpGet("{id}")]
        public ActionResult<Mision> Get(int id)
        {
            var mision = _misionService.GetById(id);
            if (mision == null)
            {
                return NotFound();
            }
            return Ok(mision);
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] Mision mision)
        {
            _misionService.Add(mision);
            return CreatedAtAction(nameof(Get), new { id = mision.id }, mision);
        }

        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Mision mision)
        {
            _misionService.Update(id, mision);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _misionService.Delete(id);
            return NoContent();
        }

        
        [HttpPost("{id}/Aceptar")]
        public ActionResult AceptarMision(int id)
        {
            _misionService.AceptarMision(id);
            return Ok();
        }

        
        [HttpPost("{id}/Completar")]
        public ActionResult CompletarMision(int id)
        {
            _misionService.CompletarMision(id);
            return Ok();
        }

        
        [HttpPost("{id}/AgregarObjetivo")]
        public ActionResult AgregarObjetivo(int id, [FromBody] string objetivo)
        {
            _misionService.AgregarObjetivo(id, objetivo);
            return Ok();
        }

        
        [HttpPost("{id}/EliminarObjetivo")]
        public ActionResult EliminarObjetivo(int id, [FromBody] string objetivo)
        {
            _misionService.EliminarObjetivo(id, objetivo);
            return Ok();
        }
    }
}