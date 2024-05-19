using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));


builder.Services.AddControllers();

builder.Services.AddTransient<ICarcelService,CarcelService>();
builder.Services.AddTransient<IModuloService,ModuloService>();
builder.Services.AddTransient<ISancionService,SancionService>();
builder.Services.AddTransient<IPresoService,PresoService>();
builder.Services.AddTransient<IGuardiaService,GuardiaService>();
builder.Services.AddTransient<TiendaService,TiendaService>();
builder.Services.AddTransient<IProductoService,ProductoService>();
builder.Services.AddTransient<ILoginService,LoginService>();
builder.Services.AddTransient<IRegistroTiendaService,RegistroTiendaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();