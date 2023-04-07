using HexagonalCleanArchitecture.Api.Filtros;
using HexagonalCleanArchitecture.Infraestructura.Extensiones;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
const string MyCor = "Mycors";

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("HexagonalCleanArchitecture.Applicacion")));
builder.Services.AddAutoMapper(Assembly.Load("HexagonalCleanArchitecture.Applicacion"));

builder.Services.ServiciosDominio();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<UnhandledExceptionFilterAttribute>();
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
