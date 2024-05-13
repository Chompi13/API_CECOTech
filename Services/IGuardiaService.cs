using API.Models;

namespace API.Services{
    public interface IGuardiaService{

         List<Guardia> GetAll();
         Task<Guardia> GetGuardia(int id);
        Task<Guardia> CreateGuardia(Guardia guardia);
         Task<Guardia> UpdateGuardia(Guardia guardia);
         Task<Guardia> DeleteGuardia(int id);


    }
}