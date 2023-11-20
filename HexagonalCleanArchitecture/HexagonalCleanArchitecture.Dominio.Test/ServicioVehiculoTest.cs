using HexagonalCleanArchitecture.Dominio.Entidades;
using HexagonalCleanArchitecture.Dominio.Excepciones;
using HexagonalCleanArchitecture.Dominio.Puertos.Repositorio;
using HexagonalCleanArchitecture.Dominio.Recursos;
using HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace HexagonalCleanArchitecture.Dominio.Test;

public class ServicioVehiculoTest
{
    readonly IVehiculoRepositorio _vehiculoRepositorio;
    readonly ServicioVehiculo _servicioVehiculo;
    public ServicioVehiculoTest()
    {
        _vehiculoRepositorio = Substitute.For<IVehiculoRepositorio>();
        _servicioVehiculo = new ServicioVehiculo(_vehiculoRepositorio);
    }

    [Fact]
    public void Guardar_Vehiculo_Exitoso()
    {
        // arrange
        var vehiculoGuardar = new Vehiculo(marca: "Honda", color: "Blanco", modelo: 2008, tipoVehiculo: Enumerados.TipoVehiculo.Automovil);

        // act
        var result = _servicioVehiculo.GuardarVehiculo(vehiculoGuardar);

        // assert
        Assert.True(result.IsCompletedSuccessfully);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 1).AddAsync(vehiculoGuardar).IsCompletedSuccessfully);
    }

    [Fact]
    public void Actualizar_Vehiculo_Exitoso()
    {
        // arrange
        var idVehiculo = Guid.NewGuid();
        var vehiculoAnterior = new Vehiculo(marca: "Kia", color: "Blanco", modelo: 2021, tipoVehiculo: Enumerados.TipoVehiculo.Automovil)
        {
            Id = idVehiculo
        };

        var vehiculoActualizar = new Vehiculo(marca: "Honda", color: "Blanco", modelo: 2021, tipoVehiculo: Enumerados.TipoVehiculo.Automovil)
        {
            Id = idVehiculo
        };

        _vehiculoRepositorio.GetByIdAsync(id: idVehiculo).Returns(vehiculoAnterior);

        // act
        var result = _servicioVehiculo.ActualizarVehiculo(vehiculoActualizar);

        // assert
        Assert.True(result.IsCompletedSuccessfully);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 1).GetByIdAsync(idVehiculo).IsCompletedSuccessfully);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 1).UpdateAsync(vehiculoActualizar).IsCompletedSuccessfully);
    }

    [Fact]
    public void Eliminar_Vehiculo_Exitoso()
    {
        // arrange
        var idVehiculo = Guid.NewGuid();
        var vehiculoBd = new Vehiculo(marca: "Kia", color: "Blanco", modelo: 2021, tipoVehiculo: Enumerados.TipoVehiculo.Automovil)
        {
            Id = idVehiculo
        };

        _vehiculoRepositorio.GetByIdAsync(id: idVehiculo).Returns(vehiculoBd);

        // act
        var result = _servicioVehiculo.EliminarVehiculo(idVehiculo);

        // assert
        Assert.True(result.IsCompletedSuccessfully);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 1).GetByIdAsync(idVehiculo).IsCompletedSuccessfully);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 1).DeleteAsync(vehiculoBd).IsCompletedSuccessfully);
    }

    [Fact]
    public async Task Guardar_VehiculoMarcaNoPermitida_Error()
    {
        // arrange
        var vehiculoGuardar = new Vehiculo(marca: "string", color: "Blanco", modelo: 2008, tipoVehiculo: Enumerados.TipoVehiculo.Automovil);

        // act
        var excepcion = await Assert.ThrowsAsync<VehiculoException>(async () => await _servicioVehiculo.GuardarVehiculo(vehiculoGuardar));

        // assert
        Assert.Equal(string.Format(RecursosAplicacion.VehiculoMarcaNoPermitida, vehiculoGuardar.Marca), excepcion.Message);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 0).AddAsync(vehiculoGuardar).IsCompletedSuccessfully);
    }

    [Fact]
    public async Task Consultar_VehiculoPorIdNoExiste_Error()
    {
        // arrange
        var idVehiculo = Guid.NewGuid();
        _vehiculoRepositorio.GetByIdAsync(id: idVehiculo).ReturnsNullForAnyArgs();

        // act
        var excepcion = await Assert.ThrowsAsync<VehiculoException>(async () => await _servicioVehiculo.ConsultarVehiculoPorId(idVehiculo));

        // assert
        Assert.Equal(RecursosAplicacion.VehiculoNoExiste, excepcion.Message);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 1).GetByIdAsync(idVehiculo).IsCompletedSuccessfully);
    }

    [Theory]
    [MemberData(nameof(ConsultaVehiculosExito))]
    public async Task Consultar_VehiculoPorId_Exitoso(Guid idVehiculo, Vehiculo vehiculo)
    {
        // arrange
        _vehiculoRepositorio.GetByIdAsync(id: idVehiculo).Returns(vehiculo);

        // act
        var vehiculoBd = await _servicioVehiculo.ConsultarVehiculoPorId(idVehiculo);

        // assert
        Assert.Equal(vehiculo.Id, vehiculoBd.Id);
        Assert.Equal(vehiculo.TipoVehiculo, vehiculoBd.TipoVehiculo);
        Assert.True(_vehiculoRepositorio.ReceivedWithAnyArgs(requiredNumberOfCalls: 1).GetByIdAsync(idVehiculo).IsCompletedSuccessfully);
    }

    public static IEnumerable<object[]> ConsultaVehiculosExito()
    {
        // parametros de test ok
        yield return new object[]
        {
            new Guid("7655882b-5675-4caf-8cf6-73c3bbbdd7b3"),
            new Vehiculo(marca: "Honda", color:"Blanco", modelo: 2008, tipoVehiculo: Enumerados.TipoVehiculo.Automovil)
            {
                Id = Guid.NewGuid(),
            }
        };

        yield return new object[]
        {
            new Guid("3e2b60d2-e8ca-4354-9d76-2227e14479bf"),
            new Vehiculo(marca: "Mazda", color:"Negro", modelo: 2020, tipoVehiculo: Enumerados.TipoVehiculo.Automovil)
            {
                Id = Guid.NewGuid(),
            }
        };

        yield return new object[]
        {
            new Guid("7822559e-5267-481f-9a8e-98c1336f45e2"),
            new Vehiculo(marca: "Hero", color:"", modelo: 2001, tipoVehiculo: Enumerados.TipoVehiculo.Motocicleta)
            {
                Id = Guid.NewGuid(),
            }
        };

        yield return new object[]
        {
            new Guid("8b4d9806-b661-47c7-aec3-a1162185fb91"),
            new Vehiculo(marca: "yamaha", color:"", modelo: 2002, tipoVehiculo: Enumerados.TipoVehiculo.Motocicleta)
            {
                Id = Guid.NewGuid(),
            }
        };
    }
}