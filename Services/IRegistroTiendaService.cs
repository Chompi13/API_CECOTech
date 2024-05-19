using API.Models;

namespace API.Services{
    public interface IRegistroTiendaService{

         List<RegistroTienda> GetAll();
         Task<RegistroTienda> GetRegistroTienda(int id);
        Task<RegistroTienda> CreateRegistroTienda(RegistroTienda registroTienda);
         Task<RegistroTienda> UpdateRegistroTienda(RegistroTienda registroTienda);
         Task<RegistroTienda> DeleteRegistroTienda(int id);


    }
}