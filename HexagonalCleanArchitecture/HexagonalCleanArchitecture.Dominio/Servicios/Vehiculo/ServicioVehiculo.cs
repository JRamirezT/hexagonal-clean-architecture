using HexagonalCleanArchitecture.Dominio.Excepciones;
using HexagonalCleanArchitecture.Dominio.Puertos.Repositorio;
using HexagonalCleanArchitecture.Dominio.Recursos;

namespace HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;

public class ServicioVehiculo
{
    private readonly IVehiculoRepositorio _vehiculoRepositorio;
    const string MarcaNoPermitida = "string";

    public ServicioVehiculo(IVehiculoRepositorio vehiculoRepositorio)
    {
        _vehiculoRepositorio = vehiculoRepositorio;
    }
    public async Task GuardarVehiculo(Entidades.Vehiculo vehiculo)
    {
        ValidacionesGeneralesVehiculo(vehiculo.Marca);
        await Guardar(vehiculo);
    }

    public async Task<Entidades.Vehiculo> ConsultarVehiculoPorId(Guid Id)
    {
        var vehiculo = await _vehiculoRepositorio.GetByIdAsync(Id);
        return vehiculo is null ? throw new VehiculoException(RecursosAplicacion.VehiculoNoExiste) : vehiculo;
    }

    public async Task ActualizarVehiculo(Entidades.Vehiculo vehiculo)
    {
        ValidacionesGeneralesVehiculo(vehiculo.Marca);
        var vehiculoBd = await ConsultarVehiculoPorId(vehiculo.Id);

        vehiculoBd.Marca = vehiculo.Marca;
        vehiculoBd.Color = vehiculo.Color;
        vehiculoBd.Modelo = vehiculo.Modelo;
        vehiculoBd.TipoVehiculo = vehiculo.TipoVehiculo;

        await Actualizar(vehiculoBd);
    }

    public async Task EliminarVehiculo(Guid Id)
    {
        var vehiculoBd = await ConsultarVehiculoPorId(Id);
        await Eliminar(vehiculoBd);
    }

    private static void ValidacionesGeneralesVehiculo(string Marca)
    {
        if (Marca.ToLower().Equals(MarcaNoPermitida))
        {
            throw new VehiculoException(string.Format(RecursosAplicacion.VehiculoMarcaNoPermitida, MarcaNoPermitida));
        }
    }

    private async Task Guardar(Entidades.Vehiculo vehiculo)
    {
        await _vehiculoRepositorio.AddAsync(vehiculo);
    }

    private async Task Actualizar(Entidades.Vehiculo vehiculo)
    {
        await _vehiculoRepositorio.UpdateAsync(vehiculo);
    }

    private async Task Eliminar(Entidades.Vehiculo vehiculo)
    {
        await _vehiculoRepositorio.DeleteAsync(vehiculo);
    }
}
