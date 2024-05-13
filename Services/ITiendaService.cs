using API.Models;

namespace API.Services{
    public interface ITiendaService{

         List<Tienda> GetAll();
         Task<Tienda> GetTienda(int id);
        Task<Tienda> CreateTienda(Tienda tienda);
         Task<Tienda> UpdateTienda(Tienda tienda);
         Task<Tienda> DeleteTienda(int id);


    }
}