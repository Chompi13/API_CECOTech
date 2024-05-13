using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarcelController : ControllerBase
{
    private readonly ICarcelService _service;
    public CarcelController(ICarcelService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Carcel>> GetTodos() {
        var carcel = _service.GetAll();
        if(carcel.Any()){
            return carcel;
        }
        return NotFound("Aun no hay carceles");
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Carcel>> Get(int id) {
        var carcel = await _service.GetCarcel(id);
        if(carcel!=null){
            return carcel;
        }
        return NotFound("No se ha encontrado la carcel");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Carcel>> Delete(int id) {
        var carcel = await _service.DeleteCarcel(id);
        if(carcel!=null){
            return carcel;
        }
        return NotFound("No se ha podido eliminar la carcel");
    }
    [HttpPut]
    public async Task<ActionResult<Carcel>> Update(Carcel car) {
        var carcel = await _service.UpdateCarcel(car);
        if(carcel!=null){
            return carcel;
        }
        return NotFound("No se ha podido actualizar la carcel");
    }

     [HttpPost]
    public async Task<ActionResult<Carcel>> Crear(Carcel car) {
        var carcel = await _service.CreateCarcel(car);
        if(carcel!= null){
            return carcel;
        }
        return NotFound("No se ha podido crear la carcel");
    }
}