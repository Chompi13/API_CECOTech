using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class PresoService : IPresoService{

        private readonly DataContext context;

        public PresoService(DataContext _context){
            context=_context;
        }

        public async Task<Preso> CreatePreso(Preso preso)
        {
            await context.preso.AddAsync(preso);
            await context.SaveChangesAsync();
            return preso;
        }

        public async Task<Preso> DeletePreso(int id)
        {
            var preso = await context.preso.FirstOrDefaultAsync(c => c.id == id);
            context.preso.Remove(preso);
            await context.SaveChangesAsync();
            return preso;
        }

        public List<Preso> GetAll()
        {
            return context.preso.ToList();
        }

        public async Task<Preso> GetPreso(int id)
        {
            return await context.preso.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Preso> UpdatePreso(Preso preso)
        {
            context.preso.Update(preso);
            await context.SaveChangesAsync();
            return preso;
        }
    }
}