using HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;
using HexagonalCleanArchitecture.Applicacion.Vehiculo.Dto;
using HexagonalCleanArchitecture.Dominio.Entidades;
using HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace HexagonalCleanArchitecture.Api.Test;

[Collection("ApiCollection collection")]
public class VehiculoControllerTest
{
    const string API_BASE = "/api/vehiculo";

    readonly HttpClient _client;
    readonly ApiTestApp _apiAppBuilder;
    readonly JsonSerializerOptions _opciones;

    public VehiculoControllerTest(ApiTestApp apiTestApp)
    {
        _apiAppBuilder = apiTestApp;
        _client = _apiAppBuilder.CreateClient();
        _opciones = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    [Fact]
    public async Task Crear_Automovil_Exitoso()
    {
        //Arrange
        var command = new VehiculoCommand("MiMarca", "Rojo", 2025, Dominio.Enumerados.TipoVehiculo.Automovil);

        //Act
        var httpResponse = await _client.PostAsJsonAsync($"{API_BASE}", command);

        using var scope = _apiAppBuilder.Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Vehiculo>>();
        var vehiculo = await repository.GetAsync(vehiculo => vehiculo.Marca == command.Marca);

        //Assert
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(vehiculo);
        Assert.True(vehiculo.Any());
        Assert.Equal(vehiculo.First().Color, command.Color);
    }

    [Fact]
    public async Task Obtener_AutomovilPorId_Exitoso()
    {
        //Arrange
        var modelo = 2025;
        var IdVehiculo = new Guid("4ed869f2-bb74-4ff4-9713-cc6e74f78b49");

        //Act
        var httpResponse = await _client.GetAsync($"{API_BASE}?Id={IdVehiculo}");
        var response = await httpResponse.Content.ReadAsStringAsync();
        var vehiculoDto = JsonSerializer.Deserialize<VehiculoDto>(response, _opciones);

        //Assert
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(vehiculoDto);
        Assert.Equal(vehiculoDto.Modelo, modelo);
    }

    [Fact]
    public async Task Actualizar_Automovil_Exitoso()
    {
        //Arrange
        var idVehiculo = new Guid("4ed869f2-bb74-4ff4-9713-cc6e74f78b44");
        var command = new VehiculoUpdateCommand(idVehiculo,
                                                "Vehiculo_Actualizado",
                                                "Rojo",
                                                2025,
                                                Dominio.Enumerados.TipoVehiculo.Motocicleta);
        //Act
        var contenidoSolicitud = new StringContent(JsonSerializer.Serialize(command), System.Text.Encoding.UTF8, "text/json");
        var httpResponse = await _client.PutAsync($"{API_BASE}", contenidoSolicitud);

        using var scope = _apiAppBuilder.Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Vehiculo>>();
        var vehiculo = await repository.GetByIdAsync(idVehiculo);

        //Assert
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(vehiculo);
        Assert.Equal(vehiculo.Marca, command.Marca);
        Assert.Equal(vehiculo.TipoVehiculo, command.TipoVehiculo);
    }

    [Fact]
    public async Task Eliminar_Automovil_Exitoso()
    {
        //Arrange
        var idVehiculo = new Guid("46f70633-4496-4124-bc76-ce9f7c073ee0");

        //Act
        var httpResponse = await _client.DeleteAsync($"{API_BASE}?Id={idVehiculo}");

        using var scope = _apiAppBuilder.Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Vehiculo>>();
        var vehiculo = await repository.GetByIdAsync(idVehiculo);

        //Assert
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.Null(vehiculo);
    }
}