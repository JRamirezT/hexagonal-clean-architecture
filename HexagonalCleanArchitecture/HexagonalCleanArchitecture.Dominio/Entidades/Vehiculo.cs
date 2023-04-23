using HexagonalCleanArchitecture.Dominio.Entidades.Base;
using HexagonalCleanArchitecture.Dominio.Enumerados;
using HexagonalCleanArchitecture.Dominio.Excepciones;
using HexagonalCleanArchitecture.Dominio.Recursos;

namespace HexagonalCleanArchitecture.Dominio.Entidades;

public class Vehiculo : EntidadBase
{
    const int ModeloMinimo = 2000;
    public string Marca { get; set; }
    public string Color { get; set; }
    public int Modelo { get; set; }
    public TipoVehiculo TipoVehiculo { get; set; }

    public Vehiculo(string marca, string color, int modelo, TipoVehiculo tipoVehiculo)
    {
        Marca = marca ?? throw new ValidacionesCamposException(string.Format(RecursosAplicacion.CampoRequerido, nameof(marca)));
        Color = color ?? throw new ValidacionesCamposException(string.Format(RecursosAplicacion.CampoRequerido, nameof(color)));
        Modelo = modelo < ModeloMinimo ? throw new ValidacionesCamposException(string.Format(RecursosAplicacion.VehiculoModeloNoValido, ModeloMinimo)) : modelo;
        TipoVehiculo = tipoVehiculo;
    }
}
