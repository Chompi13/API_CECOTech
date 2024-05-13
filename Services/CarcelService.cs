using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class CarcelService : ICarcelService{

        private readonly DataContext context;

        public CarcelService(DataContext _context){
            context=_context;
        }

        public async Task<Carcel> CreateCarcel(Carcel carcel)
        {
            await context.carcel.AddAsync(carcel);
            await context.SaveChangesAsync();
            return carcel;
        }

        public async Task<Carcel> DeleteCarcel(int id)
        {
            var carcel = await context.carcel.FirstOrDefaultAsync(c => c.id == id);
            context.carcel.Remove(carcel);
            await context.SaveChangesAsync();
            return carcel;
        }

        public List<Carcel> GetAll()
        {
            return context.carcel.ToList();
        }

        public async Task<Carcel> GetCarcel(int id)
        {
            return await context.carcel.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Carcel> UpdateCarcel(Carcel carcel)
        {
            context.carcel.Update(carcel);
            await context.SaveChangesAsync();
            return carcel;
        }
    }
}