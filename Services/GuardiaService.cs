using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class GuardiaService : IGuardiaService{

        private readonly DataContext context;

        public GuardiaService(DataContext _context){
            context=_context;
        }

        public async Task<Guardia> CreateGuardia(Guardia guardia)
        {
            await context.guardia.AddAsync(guardia);
            await context.SaveChangesAsync();
            return guardia;
        }

        public async Task<Guardia> DeleteGuardia(int id)
        {
            var guardia = await context.guardia.FirstOrDefaultAsync(c => c.id == id);
            context.guardia.Remove(guardia);
            await context.SaveChangesAsync();
            return guardia;
        }

        public List<Guardia> GetAll()
        {
            return context.guardia.ToList();
        }

        public async Task<Guardia> GetGuardia(int id)
        {
            return await context.guardia.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Guardia> UpdateGuardia(Guardia guardia)
        {
            context.guardia.Update(guardia);
            await context.SaveChangesAsync();
            return guardia;
        }
    }
}