using API.Models;

namespace API.Services{
    public interface IProductoService{

         List<Producto> GetAll();
         Task<Producto> GetProducto(int id);
        Task<Producto> CreateProducto(Producto producto);
         Task<Producto> UpdateProducto(Producto producto);
         Task<Producto> DeleteProducto(int id);


    }
}