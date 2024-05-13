using API.Models;

namespace API.Services{
    public interface IPresoService{

         List<Preso> GetAll();
         Task<Preso> GetPreso(int id);
        Task<Preso> CreatePreso(Preso preso);
         Task<Preso> UpdatePreso(Preso preso);
         Task<Preso> DeletePreso(int id);


    }
}