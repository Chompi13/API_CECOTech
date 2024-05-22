using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TiendaController : ControllerBase
{
    private readonly ITiendaService _service;
    public TiendaController(ITiendaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async ActionResult<List<Tienda>> GetTodos() {
        var tienda = await _service.GetAll();
        if(tienda.Any()){
            return tienda;
        }
        return NotFound("Aun no hay tiendas");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tienda>> Get(int id) {
        var tienda = await _service.GetTienda(id);
        if(tienda!=null){
            return tienda;
        }
        return NotFound("No se ha encontrado la tienda");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Tienda>> Delete(int id) {
        var tienda = await _service.DeleteTienda(id);
        if(tienda!=null){
            return tienda;
        }
        return NotFound("No se ha podido eliminar la tienda");
    }
    [HttpPut]
    public async Task<ActionResult<Tienda>> Update(Tienda car) {
        var tienda = await _service.UpdateTienda(car);
        if(tienda!=null){
            return tienda;
        }
        return NotFound("No se ha podido actualizar la tienda");
    }

     [HttpPost]
    public async Task<ActionResult<Tienda>> Crear(Tienda tien) {
        var tienda = await _service.CreateTienda(tien);
        if(tienda!= null){
            return tienda;
        }
        return NotFound("No se ha podido crear la tienda");
    }
}