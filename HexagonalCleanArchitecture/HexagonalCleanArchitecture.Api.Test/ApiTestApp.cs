using HexagonalCleanArchitecture.Dominio.Entidades;
using HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace HexagonalCleanArchitecture.Api.Test;

public class ApiTestApp : WebApplicationFactory<Program>, IAsyncLifetime
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var BaseDatosEnMemoria = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<HexagonalContext>));
            services.AddDbContext<HexagonalContext>(options => options.UseInMemoryDatabase("Testing", BaseDatosEnMemoria));
        });

        return base.CreateHost(builder);
    }

    private async Task PoblarBaseDatos()
    {
        using var scope = Services.CreateScope();

        var grupoRepository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Vehiculo>>();
        foreach (var grupo in ObtenerVehiculos())
        {
            await grupoRepository.AddAsync(grupo);
        }
    }

    private static List<Vehiculo> ObtenerVehiculos()
    {
        return new List<Vehiculo>()
        {
            new("Vehiculo_Actualizar", "blanco", 2025, Dominio.Enumerados.TipoVehiculo.Automovil)
            {
                Id = new Guid("4ed869f2-bb74-4ff4-9713-cc6e74f78b49")
            },
            new("Vehiculo_Actualizar", "blanco", 2023, Dominio.Enumerados.TipoVehiculo.Automovil)
            {
                Id = new Guid("4ed869f2-bb74-4ff4-9713-cc6e74f78b44")
            },
            new("Vehiculo_Eliminar", "Negro", 2024, Dominio.Enumerados.TipoVehiculo.Motocicleta)
            {
                Id = new Guid("46f70633-4496-4124-bc76-ce9f7c073ee0")
            }
        };
    }

    public async Task InitializeAsync()
    {
        await PoblarBaseDatos();
    }

    Task IAsyncLifetime.DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
