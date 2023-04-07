using AutoMapper;
using HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo;

public class VehiculoMapper : Profile
{
    public VehiculoMapper()
    {
        CreateMap<VehiculoCommand, Dominio.Entidades.Vehiculo>().ReverseMap();
    }
}
