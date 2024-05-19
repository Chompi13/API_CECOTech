using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class RegistroTiendaService : IRegistroTiendaService{

        private readonly DataContext context;

        public RegistroTiendaService(DataContext _context){
            context=_context;
        }

        public async Task<RegistroTienda> CreateRegistroTienda(RegistroTienda registroTienda)
        {
            await context.registroTienda.AddAsync(registroTienda);
            await context.SaveChangesAsync();
            return registroTienda;
        }

        public async Task<RegistroTienda> DeleteRegistroTienda(int id)
        {
            var registroTienda = await context.registroTienda.FirstOrDefaultAsync(c => c.id == id);
            context.registroTienda.Remove(registroTienda);
            await context.SaveChangesAsync();
            return registroTienda;
        }

        public List<RegistroTienda> GetAll()
        {
            return context.registroTienda.ToList();
        }

        public async Task<RegistroTienda> GetRegistroTienda(int id)
        {
            return await context.registroTienda.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<RegistroTienda> UpdateRegistroTienda(RegistroTienda registroTienda)
        {
            context.registroTienda.Update(registroTienda);
            await context.SaveChangesAsync();
            return registroTienda;
        }
    }
}