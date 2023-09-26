using CrudOfertas.Api.Repositorios.Implementacoes;
using CrudOfertas.Api.Repositorios.Interfaces;
using CrudOfertas.Api.Servicos.Implementacos;
using CrudOfertas.Api.Servicos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOfertaService, OfertaService>();
builder.Services.AddScoped<IOfertaRepository, OfertaRepository>();

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
