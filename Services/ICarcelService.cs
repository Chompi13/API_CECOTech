using API.Models;

namespace API.Services{
    public interface ICarcelService{

         List<Carcel> GetAll();
         Task<Carcel> GetCarcel(int id);
        Task<Carcel> CreateCarcel(Carcel carcel);
         Task<Carcel> UpdateCarcel(Carcel carcel);
         Task<Carcel> DeleteCarcel(int id);


    }
}