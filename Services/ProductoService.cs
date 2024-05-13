using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class ProductoService : IProductoService{

        private readonly DataContext context;

        public ProductoService(DataContext _context){
            context=_context;
        }

        public async Task<Producto> CreateProducto(Producto producto)
        {
            await context.producto.AddAsync(producto);
            await context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> DeleteProducto(int id)
        {
            var producto = await context.producto.FirstOrDefaultAsync(c => c.id == id);
            context.producto.Remove(producto);
            await context.SaveChangesAsync();
            return producto;
        }

        public List<Producto> GetAll()
        {
            return context.producto.ToList();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await context.producto.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Producto> UpdateProducto(Producto producto)
        {
            context.producto.Update(producto);
            await context.SaveChangesAsync();
            return producto;
        }
    }
}