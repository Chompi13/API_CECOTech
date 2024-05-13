using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class SancionController : ControllerBase
{
    private readonly ISancionService _service;
    public SancionController(ISancionService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Sancion>> GetTodos() {
        var sancion = _service.GetAll();
        if(sancion.Any()){
            return sancion;
        }
        return NotFound("Aun no hay sanciones");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sancion>> Get(int id) {
        var sancion = await _service.GetSancion(id);
        if(sancion!=null){
            return sancion;
        }
        return NotFound("No se ha encontrado la sancion");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Sancion>> Delete(int id) {
        var sancion = await _service.DeleteSancion(id);
        if(sancion!=null){
            return sancion;
        }
        return NotFound("No se ha podido eliminar la sancion");
    }
    [HttpPut]
    public async Task<ActionResult<Sancion>> Update(Sancion car) {
        var sancion = await _service.UpdateSancion(car);
        if(sancion!=null){
            return sancion;
        }
        return NotFound("No se ha podido actualizar la sancion");
    }

     [HttpPost]
    public async Task<ActionResult<Sancion>> Crear(Sancion sanc) {
        var sancion = await _service.CreateSancion(sanc);
        if(sancion!= null){
            return sancion;
        }
        return NotFound("No se ha podido crear la sancion");
    }
}