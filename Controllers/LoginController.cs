using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _service;
    public LoginController(ILoginService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Login>> GetTodos() {
        var login = _service.GetAll();
        if(login.Any()){
            return login;
        }
        return NotFound("Aun no hay usuarios");
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Login>> Get(int id) {
        var login = await _service.GetLogin(id);
        if(login!=null){
            return login;
        }
        return NotFound("No se ha encontrado el usuario");
    }

    [HttpGet("login")]
    public async Task<ActionResult<Login>> Get(string user, string pwd) {
        var login = await _service.Login(user,pwd);
        if(login==-1){
            return NotFound("No se ha encontrado el usuario");
        }else if(login==-2){
            return NotFound("La contraseña es incorrecta");
        }else{
            return await _service.GetLogin(login);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Login>> Delete(int id) {
        var login = await _service.DeleteLogin(id);
        if(login!=null){
            return login;
        }
        return NotFound("No se ha podido eliminar el usuario");
    }
    [HttpPut]
    public async Task<ActionResult<Login>> Update(Login car) {
        var login = await _service.UpdateLogin(car);
        if(login!=null){
            return login;
        }
        return NotFound("No se ha podido actualizar el usuario");
    }

     [HttpPost]
    public async Task<ActionResult<Login>> Crear(Login log) {
        var login = await _service.CreateLogin(log);
        if(login!= null){
            return login;
        }
        return NotFound("No se ha podido crear el usuario");
    }
}