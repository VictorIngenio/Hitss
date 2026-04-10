using CRMHitssBack.Models.Context;
using CRMHitssBack.Models.Entities;
using CRMHitssBack.Repository.ClienteRep;
using CRMHitssBack.Service.ClienteServ;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conexion = builder.Configuration.GetConnectionString("CMRHitssConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option => option.AddPolicy("AllowAll", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();

// Creacion de la base de datos en memoria
//builder.Services.AddDbContext<ClienteContext>(options => options.UseInMemoryDatabase("DBMemory"));

//Uso de base de datos SQL Server local
builder.Services.AddDbContext<ClienteContext>(options => options.UseSqlServer(conexion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

//Crear scope para inyección de depencias para datos In-Memory
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ClienteContext>();
//    SeedData(context);
//}

app.Run(); 

//Datos iniciales In-Memory
//void SeedData(ClienteContext context)
//{
//    context.Cliente.AddRange(
//        new Cliente
//        {
//            Id = 1,
//            Nombre = "Juan Perez",
//            Email = "jperez@outlook.com",
//            Telefono = "3134985338",
//            NombreFinca = "La Esperanza",
//            Hectareas = "200"
//        },
//        new Cliente
//        {
//            Id = 2,
//            Nombre = "María Gonzalez",
//            Email = "mgonzalez@gmail.com",
//            Telefono = "3208275235",
//            NombreFinca = "Los Gonzalez",
//            Hectareas = "300"
//        }
//    );

//    context.SaveChanges();
//}
