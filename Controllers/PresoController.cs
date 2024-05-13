using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PresoController : ControllerBase
{
    private readonly IPresoService _service;
    public PresoController(IPresoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Preso>> GetTodos() {
        var preso = _service.GetAll();
        if(preso.Any()){
            return preso;
        }
        return NotFound("Aun no hay presos");
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Preso>> Get(int id) {
        var preso = await _service.GetPreso(id);
        if(preso!=null){
            return preso;
        }
        return NotFound("No se ha encontrado el preso");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Preso>> Delete(int id) {
        var preso = await _service.DeletePreso(id);
        if(preso!=null){
            return preso;
        }
        return NotFound("No se ha podido eliminar el preso");
    }
    [HttpPut]
    public async Task<ActionResult<Preso>> Update(Preso car) {
        var preso = await _service.UpdatePreso(car);
        if(preso!=null){
            return preso;
        }
        return NotFound("No se ha podido actualizar el preso");
    }

     [HttpPost]
    public async Task<ActionResult<Preso>> Crear(Preso pre) {
        var preso = await _service.CreatePreso(pre);
        if(preso!= null){
            return preso;
        }
        return NotFound("No se ha podido crear el preso");
    }
}