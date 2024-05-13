using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class SancionService : ISancionService{

        private readonly DataContext context;

        public SancionService(DataContext _context){
            context=_context;
        }

        public async Task<Sancion> CreateSancion(Sancion sancion)
        {
            await context.sancion.AddAsync(sancion);
            await context.SaveChangesAsync();
            return sancion;
        }

        public async Task<Sancion> DeleteSancion(int id)
        {
            var sancion = await context.sancion.FirstOrDefaultAsync(c => c.id == id);
            context.sancion.Remove(sancion);
            await context.SaveChangesAsync();
            return sancion;
        }

        public List<Sancion> GetAll()
        {
            return context.sancion.ToList();
        }

        public async Task<Sancion> GetSancion(int id)
        {
            return await context.sancion.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Sancion> UpdateSancion(Sancion sancion)
        {
            context.sancion.Update(sancion);
            await context.SaveChangesAsync();
            return sancion;
        }
    }
}