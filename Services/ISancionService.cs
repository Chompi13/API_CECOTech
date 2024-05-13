using API.Models;

namespace API.Services{
    public interface ISancionService{

         List<Sancion> GetAll();
         Task<Sancion> GetSancion(int id);
        Task<Sancion> CreateSancion(Sancion sancion);
         Task<Sancion> UpdateSancion(Sancion sancion);
         Task<Sancion> DeleteSancion(int id);


    }
}