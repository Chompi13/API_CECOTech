using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class TiendaService : ITiendaService{

        private readonly DataContext context;

        public TiendaService(DataContext _context){
            context=_context;
        }

        public async Task<Tienda> CreateTienda(Tienda tienda)
        {
            await context.tienda.AddAsync(tienda);
            await context.SaveChangesAsync();
            return tienda;
        }

        public async Task<Tienda> DeleteTienda(int id)
        {
            var tienda = await context.tienda.FirstOrDefaultAsync(c => c.id == id);
            context.tienda.Remove(tienda);
            await context.SaveChangesAsync();
            return tienda;
        }

        public async Task<List<Tienda>> GetAll()
        {
            return await context.tienda.ToListAsync();
        }

        public async Task<Tienda> GetTienda(int id)
        {
            return await context.tienda.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Tienda> UpdateTienda(Tienda tienda)
        {
            context.tienda.Update(tienda);
            await context.SaveChangesAsync();
            return tienda;
        }
    }
}