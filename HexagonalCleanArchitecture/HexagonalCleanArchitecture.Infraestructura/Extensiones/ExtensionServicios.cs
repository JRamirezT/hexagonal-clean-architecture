using HexagonalCleanArchitecture.Dominio.Puertos.Repositorio;
using HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;
using HexagonalCleanArchitecture.Infraestructura.Adaptadores.Repositorios;
using HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;
using Microsoft.Extensions.DependencyInjection;

namespace HexagonalCleanArchitecture.Infraestructura.Extensiones;

public static class ExtensionServicios
{
    public static IServiceCollection ServiciosDominio(this IServiceCollection services)
    {
        // Inyectamos los servicios
        services.AddTransient<ServicioVehiculo>();

        // Inyectamos los repositorios
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient(typeof(IVehiculoRepositorio), typeof(VehiculoRepositorio));

        return services;
    }
}

