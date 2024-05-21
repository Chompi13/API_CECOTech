using API.Models;

namespace API.Services{
    public interface ILoginService{

         List<Login> GetAll();
         Task<Login> GetLogin(int id);
         Task<int> Login(string user, string pwd);
        Task<Login> CreateLogin(Login login);
         Task<Login> UpdateLogin(Login login);
         Task<Login> DeleteLogin(int id);


    }
}