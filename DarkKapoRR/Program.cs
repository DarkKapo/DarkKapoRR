using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using DarkKapoRR;
using DarkKapoRR.Repositorios;
using DarkKapoRR.Entidades;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Numerics;
using DarkKapoRR.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!; //con ! digo que el valor no sera nulo
//Inicio area servicios

builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

builder.Services.AddCors(opciones =>
{ 
    opciones.AddDefaultPolicy(config =>
    {
        config.WithOrigins(origenesPermitidos).AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddOutputCache(); //Declaracion de cache para optimizar las preguntas a la base de datos
builder.Services.AddEndpointsApiExplorer(); //Documentacion de la API
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositorioJugador, RepositorioJugador>();

builder.Services.AddAutoMapper(typeof(Program));

//Fin areas de servicio
var app = builder.Build();

//Inicio area middleware
app.UseSwagger();//se usa aca porque sabemos que se usara local, no necesitamos acceder desde otro lugar
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);//Elimina Schema
});


app.UseCors();
app.UseOutputCache(); //Uso de cache para optimizar las preguntas a la base de datos

app.MapGroup("/jugadores").MapJugadores();

//Fin area middleware

app.Run();