using CarpinchoAPI.Helpers;
using CarpinchoAPI.Models;
using CarpinchoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpinchoAPI.Controllers;

[ApiController]
[Route("api/carpincho/{carpinchoId}[controller]")]
public class HabilidadController : ControllerBase 
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int carpinchoId) 
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) {
            return NotFound(Mensajes.Carpincho.NotFound);
        }

        return Ok(carpincho.Habilidades); 
    }

    [HttpGet("{habilidadId}")]
    public ActionResult<Carpincho> GetHabilidad(int habilidadId, int carpinchoId) 
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) {
            return NotFound(Mensajes.Carpincho.NotFound);
        }

        var habilidad = carpincho.Habilidades?.FirstOrDefault(x => x.Id == habilidadId);

        if(habilidad == null) {
            return NotFound(Mensajes.Habilidad.NotFound);
        }

        return Ok(habilidad);
    }

    [HttpPost]
    public ActionResult<Carpincho> PostHabilidad(int carpinchoId, HabilidadInsert habilidadInsert) 
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) {
            return NotFound(Mensajes.Carpincho.NotFound);
        }

        var habilidadExistente = carpincho.Habilidades.FirstOrDefault(x => x.Nombre == habilidadInsert.Nombre);

        if(habilidadExistente != null) {
            return BadRequest(Mensajes.Habilidad.NombreExistente);
        }

        var maxHabilidad = carpincho.Habilidades.Max(x => x.Id);

        var habilidadNueva = new Habilidad() {
            Id = maxHabilidad + 1,
            Nombre = habilidadInsert.Nombre,
            Potencia = habilidadInsert.Potencia,
        };

        carpincho.Habilidades.Add(habilidadNueva);

        return CreatedAtAction(
            nameof(GetHabilidad),
            new { carpinchoId = carpinchoId, habilidadId = habilidadNueva.Id },
            habilidadNueva
        );
    }

    [HttpPut("{habilidadId}")]
    public ActionResult<Carpincho> PutHabilidad(int carpinchoId, int habilidadId, HabilidadInsert habilidadInsert)
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) {
            return NotFound(Mensajes.Carpincho.NotFound);
        }
        
        var habilidadExistente = carpincho.Habilidades?.FirstOrDefault(x => x.Id == habilidadId);
        
        if(habilidadExistente == null) {
            return BadRequest(Mensajes.Habilidad.NotFound);
        }

        var habilidadMismoNombre = carpincho.Habilidades.FirstOrDefault(x => x.Id != habilidadId && x.Nombre == habilidadInsert.Nombre);

        if(habilidadMismoNombre != null) {
            return BadRequest(Mensajes.Habilidad.NombreExistente);
        }

        habilidadExistente.Nombre = habilidadInsert.Nombre;
        habilidadExistente.Potencia = habilidadInsert.Potencia;

        return NoContent();
    }

    [HttpDelete("{habilidadId}")]
    public ActionResult<Carpincho> DeleteHabilidad(int carpinchoId, int habilidadId) 
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) {
            return NotFound(Mensajes.Carpincho.NotFound);
        }

        var habilidadExistente = carpincho.Habilidades?.FirstOrDefault(x => x.Id == habilidadId);

        if(habilidadExistente == null) {
            return NotFound(Mensajes.Habilidad.NotFound);
        }

        carpincho.Habilidades.Remove(habilidadExistente);

        return NoContent();
    }
}