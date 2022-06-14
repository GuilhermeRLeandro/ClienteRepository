using Microsoft.EntityFrameworkCore;
using RegistroDeClientes.Domain.Interfaces;
using RegistroDeClientes.Infra;
using RegistroDeClientes.Infra.Repositories;
using RegistroDeClientes.Service.Interfaces;
using RegistroDeClientes.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(connectionString));
builder.Services.AddScoped<IClienteRepositorie, ClienteRepositorie>();
builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
