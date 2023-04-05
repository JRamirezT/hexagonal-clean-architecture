using HexagonalCleanArchitecture.Dominio.Enumerados;

namespace HexagonalCleanArchitecture.Dominio.Entidades;

public class Vehiculo
{
    public string Marca { get; set; }
    public string Color { get; set; }
    public int Modelo { get; set; }
    public TipoVehiculo TipoVehiculo { get; set; }

    public Vehiculo(string marca, string color, int modelo, TipoVehiculo tipoVehiculo)
    {
        Marca = marca ?? throw new ArgumentNullException(nameof(marca));
        Color = color ?? throw new ArgumentNullException(nameof(color));
        Modelo = modelo;
        TipoVehiculo = tipoVehiculo;
    }
}

