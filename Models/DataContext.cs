using Microsoft.EntityFrameworkCore;

namespace API.Models{
    public class DataContext:DbContext{
        public DataContext(DbContextOptions<DataContext> options): base (options){

        }
        public DbSet<Carcel> carcel {get;set;}
        public DbSet<Modulo> modulo {get;set;}
        public DbSet<Preso> preso {get;set;}
        public DbSet<Guardia> guardia {get;set;}
        public DbSet<Tienda> tienda {get;set;}
        public DbSet<Producto> producto {get;set;} 
        public DbSet<Sancion> sancion {get;set;} 
        public DbSet<Login> login {get;set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guardia>()
            .HasIndex(p => p.nplaca)
            .IsUnique();
    }
    }
    
}