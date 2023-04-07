using HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;
using Microsoft.Extensions.DependencyInjection;

namespace HexagonalCleanArchitecture.Infraestructura.Extensiones;

public static class ExtensionServicios
{
    public static IServiceCollection ServiciosDominio(this IServiceCollection services)
    {
        services.AddTransient<ServicioVehiculo>();
        return services;
    }
}

