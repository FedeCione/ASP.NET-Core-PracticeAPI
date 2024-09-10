using CarpinchoAPI.Helpers;
using CarpinchoAPI.Models;
using CarpinchoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpinchoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarpinchoController : ControllerBase 
{
    [HttpGet]
    public ActionResult<IEnumerable<Carpincho>> GetCarpinchos() 
    {
        return Ok(CarpinchoDataStore.Current.Carpinchos);
    }

    [HttpGet("{carpinchoId}")]
    public ActionResult<Carpincho> GetCarpincho(int carpinchoId) 
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) 
        {
            return NotFound(Mensajes.Carpincho.NotFound);
        }

        return Ok(carpincho);
    }

    [HttpPost]
    public ActionResult<Carpincho> PostCarpincho(CarpinchoInsert carpinchoInsert) 
    {
        var maxCarpinchoId = CarpinchoDataStore.Current.Carpinchos.Max(x => x.Id);

        var carpinchoNuevo = new Carpincho() 
        {
            Id = maxCarpinchoId + 1,
            Nombre = carpinchoInsert.Nombre,
            Apellido = carpinchoInsert.Apellido,
        };

        CarpinchoDataStore.Current.Carpinchos.Add(carpinchoNuevo);

        return CreatedAtAction(nameof(GetCarpincho),
            new { carpinchoId = carpinchoNuevo.Id },
            carpinchoNuevo
        );
    }

    [HttpPut("{carpinchoId}")]
    public ActionResult<Carpincho> PutCarpincho([FromRoute] int carpinchoId, [FromBody] CarpinchoInsert carpinchoInsert)
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) 
        {
            return NotFound(Mensajes.Carpincho.NotFound);
        }

        carpincho.Nombre = carpinchoInsert.Nombre;
        carpincho.Apellido = carpinchoInsert.Apellido;

        return NoContent();
    }

    [HttpDelete("{carpinchoId}")]
    public ActionResult<Carpincho> DeleteCarpincho(int carpinchoId) 
    {
        var carpincho = CarpinchoDataStore.Current.Carpinchos.FirstOrDefault(x => x.Id == carpinchoId);

        if(carpincho == null) 
        {
            return NotFound(Mensajes.Carpincho.NotFound);
        }

        CarpinchoDataStore.Current.Carpinchos.Remove(carpincho);

        return NoContent();
    }
}