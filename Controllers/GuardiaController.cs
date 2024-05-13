using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GuardiaController : ControllerBase
{
    private readonly IGuardiaService _service;
    public GuardiaController(IGuardiaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Guardia>> GetTodos() {
        var guardia = _service.GetAll();
        if(guardia.Any()){
            return guardia;
        }
        return NotFound("Aun no hay guardias");
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Guardia>> Get(int id) {
        var guardia = await _service.GetGuardia(id);
        if(guardia!=null){
            return guardia;
        }
        return NotFound("No se ha encontrado el guardia");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Guardia>> Delete(int id) {
        var guardia = await _service.DeleteGuardia(id);
        if(guardia!=null){
            return guardia;
        }
        return NotFound("No se ha podido eliminar el guardia");
    }
    [HttpPut]
    public async Task<ActionResult<Guardia>> Update(Guardia car) {
        var guardia = await _service.UpdateGuardia(car);
        if(guardia!=null){
            return guardia;
        }
        return NotFound("No se ha podido actualizar el guardia");
    }

     [HttpPost]
    public async Task<ActionResult<Guardia>> Crear(Guardia guar) {
        var guardia = await _service.CreateGuardia(guar);
        if(guardia!= null){
            return guardia;
        }
        return NotFound("No se ha podido crear el guardia");
    }
}