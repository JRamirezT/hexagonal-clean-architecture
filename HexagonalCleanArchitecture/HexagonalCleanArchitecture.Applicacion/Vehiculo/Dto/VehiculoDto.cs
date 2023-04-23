using HexagonalCleanArchitecture.Dominio.Enumerados;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Dto;

public class VehiculoDto
{
    public Guid Id { get; set; }
    public string Marca { get; set; } = default!;
    public string Color { get; set; } = default!;
    public int Modelo { get; set; }
    public string TipoVehiculo { get; set; } = default!;
}

