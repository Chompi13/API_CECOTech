using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services{
    public class LoginService : ILoginService{

        private readonly DataContext context;

        public LoginService(DataContext _context){
            context=_context;
        }

        public async Task<Login> CreateLogin(Login login)
        {
            await context.login.AddAsync(login);
            await context.SaveChangesAsync();
            return login;
        }

        public async Task<Login> DeleteLogin(int id)
        {
            var login = await context.login.FirstOrDefaultAsync(c => c.id == id);
            context.login.Remove(login);
            await context.SaveChangesAsync();
            return login;
        }

        public List<Login> GetAll()
        {
            return context.login.ToList();
        }

        public async Task<Login> GetLogin(int id)
        {
            return await context.login.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<int> Login(string user, string pwd)
        {
            var u = await context.login.FirstOrDefaultAsync(c => c.nombre == user);
            if (u==null){
                return -1;
            }
            u = await context.login.FirstOrDefaultAsync(c => c.nombre == user && c.password == pwd);
            if (u==null){
                return -2;
            }
            return u.id;
        }

        public async Task<Login> UpdateLogin(Login login)
        {
            context.login.Update(login);
            await context.SaveChangesAsync();
            return login;
        }
    }
}