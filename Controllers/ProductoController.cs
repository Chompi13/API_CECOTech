using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _service;
    public ProductoController(IProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Producto>> GetTodos() {
        var producto = _service.GetAll();
        if(producto.Any()){
            return producto;
        }
        return NotFound("Aun no hay productos");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> Get(int id) {
        var producto = await _service.GetProducto(id);
        if(producto!=null){
            return producto;
        }
        return NotFound("No se ha encontrado el producto");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Producto>> Delete(int id) {
        var producto = await _service.DeleteProducto(id);
        if(producto!=null){
            return producto;
        }
        return NotFound("No se ha podido eliminar el producto");
    }
    [HttpPut]
    public async Task<ActionResult<Producto>> Update(Producto car) {
        var producto = await _service.UpdateProducto(car);
        if(producto!=null){
            return producto;
        }
        return NotFound("No se ha podido actualizar el producto");
    }

     [HttpPost]
    public async Task<ActionResult<Producto>> Crear(Producto prod) {
        var producto = await _service.CreateProducto(prod);
        if(producto!= null){
            return producto;
        }
        return NotFound("No se ha podido crear el producto");
    }
}