using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistroTiendaController : ControllerBase
{
    private readonly IRegistroTiendaService _service;
    public RegistroTiendaController(IRegistroTiendaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<RegistroTienda>> GetTodos() {
        var registroTienda = _service.GetAll();
        if(registroTienda.Any()){
            return registroTienda;
        }
        return NotFound("Aun no hay registroTiendas");
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<RegistroTienda>> Get(int id) {
        var registroTienda = await _service.GetRegistroTienda(id);
        if(registroTienda!=null){
            return registroTienda;
        }
        return NotFound("No se ha encontrado el registroTienda");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<RegistroTienda>> Delete(int id) {
        var registroTienda = await _service.DeleteRegistroTienda(id);
        if(registroTienda!=null){
            return registroTienda;
        }
        return NotFound("No se ha podido eliminar el registroTienda");
    }
    [HttpPut]
    public async Task<ActionResult<RegistroTienda>> Update(RegistroTienda car) {
        var registroTienda = await _service.UpdateRegistroTienda(car);
        if(registroTienda!=null){
            return registroTienda;
        }
        return NotFound("No se ha podido actualizar el registroTienda");
    }

     [HttpPost]
    public async Task<ActionResult<RegistroTienda>> Crear(RegistroTienda mod) {
        var registroTienda = await _service.CreateRegistroTienda(mod);
        if(registroTienda!= null){
            return registroTienda;
        }
        return NotFound("No se ha podido crear el registroTienda");
    }
}