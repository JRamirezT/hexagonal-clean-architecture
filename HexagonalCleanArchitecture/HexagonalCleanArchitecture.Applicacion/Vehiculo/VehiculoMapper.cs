using AutoMapper;
using HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;
using HexagonalCleanArchitecture.Applicacion.Vehiculo.Dto;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo;

public class VehiculoMapper : Profile
{
    public VehiculoMapper()
    {
        CreateMap<Dominio.Entidades.Vehiculo, VehiculoCommand>().ReverseMap();
        
        CreateMap<Dominio.Entidades.Vehiculo, VehiculoDto>()
        .ForMember(destino => destino.TipoVehiculo, origen => origen.MapFrom(src => src.TipoVehiculo.ToString()))
        .ReverseMap();

        CreateMap<Dominio.Entidades.Vehiculo, VehiculoUpdateCommand>().ReverseMap();
    }
}
