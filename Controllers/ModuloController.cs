using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuloController : ControllerBase
{
    private readonly IModuloService _service;
    public ModuloController(IModuloService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Modulo>> GetTodos() {
        var modulo = _service.GetAll();
        if(modulo.Any()){
            return modulo;
        }
        return NotFound("Aun no hay modulos");
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Modulo>> Get(int id) {
        var modulo = await _service.GetModulo(id);
        if(modulo!=null){
            return modulo;
        }
        return NotFound("No se ha encontrado el modulo");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Modulo>> Delete(int id) {
        var modulo = await _service.DeleteModulo(id);
        if(modulo!=null){
            return modulo;
        }
        return NotFound("No se ha podido eliminar el modulo");
    }
    [HttpPut]
    public async Task<ActionResult<Modulo>> Update(Modulo car) {
        var modulo = await _service.UpdateModulo(car);
        if(modulo!=null){
            return modulo;
        }
        return NotFound("No se ha podido actualizar el modulo");
    }

     [HttpPost]
    public async Task<ActionResult<Modulo>> Crear(Modulo mod) {
        var modulo = await _service.CreateModulo(mod);
        if(modulo!= null){
            return modulo;
        }
        return NotFound("No se ha podido crear el modulo");
    }
}