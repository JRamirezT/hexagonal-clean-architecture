using HexagonalCleanArchitecture.Api.Filtros;
using HexagonalCleanArchitecture.Infraestructura.Extensiones;
using HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
const string MyCor = "Mycors";
var _config = builder.Configuration;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("HexagonalCleanArchitecture.Applicacion")));
builder.Services.AddAutoMapper(Assembly.Load("HexagonalCleanArchitecture.Applicacion"));

builder.Services.ServiciosDominio();

// En este apartado le configuramos a los controladores el filtro de excepciones el cual realizará la estandarización
builder.Services.AddControllers(options =>
{
    options.Filters.Add<UnhandledExceptionFilterAttribute>();
});

// Configuramos el contexto de BD e igualmente se configura el nombre de la tabla de las migraciones
// con su respectivo esquema de Base de datos en el cual se trabajara
var DbSecret = _config["ConnectionStrings:BaseDatosHexagonal"];
builder.Services.AddDbContext<HexagonalContext>(options =>
{
    options.UseNpgsql(_config[DbSecret],
                      bd => bd.MigrationsHistoryTable("__MyMigrationsHistory", _config.GetSection("NombreEsquem").Value));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: MyCor,
                         builder => builder.AllowAnyOrigin()
                                           .AllowAnyMethod()
                                           .AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyCor);

app.UseAuthorization();

app.MapControllers();

app.Run();
