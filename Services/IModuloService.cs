using API.Models;

namespace API.Services{
    public interface IModuloService{

         List<Modulo> GetAll();
         Task<Modulo> GetModulo(int id);
        Task<Modulo> CreateModulo(Modulo modulo);
         Task<Modulo> UpdateModulo(Modulo modulo);
         Task<Modulo> DeleteModulo(int id);


    }
}