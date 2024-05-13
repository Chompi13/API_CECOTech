using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class ModuloService : IModuloService{

        private readonly DataContext context;

        public ModuloService(DataContext _context){
            context=_context;
        }

        public async Task<Modulo> CreateModulo(Modulo modulo)
        {
            await context.modulo.AddAsync(modulo);
            await context.SaveChangesAsync();
            return modulo;
        }

        public async Task<Modulo> DeleteModulo(int id)
        {
            var modulo = await context.modulo.FirstOrDefaultAsync(c => c.id == id);
            context.modulo.Remove(modulo);
            await context.SaveChangesAsync();
            return modulo;
        }

        public List<Modulo> GetAll()
        {
            return context.modulo.ToList();
        }

        public async Task<Modulo> GetModulo(int id)
        {
            return await context.modulo.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Modulo> UpdateModulo(Modulo modulo)
        {
            context.modulo.Update(modulo);
            await context.SaveChangesAsync();
            return modulo;
        }
    }
}