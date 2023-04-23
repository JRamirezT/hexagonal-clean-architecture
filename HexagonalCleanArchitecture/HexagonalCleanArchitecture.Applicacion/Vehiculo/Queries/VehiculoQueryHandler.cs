using AutoMapper;
using HexagonalCleanArchitecture.Applicacion.Vehiculo.Dto;
using HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;
using MediatR;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Queries;

public class VehiculoQueryHandler : IRequestHandler<VehiculoQuery, VehiculoDto>
{
    private readonly ServicioVehiculo _servicioVehiculo;
    private readonly IMapper _mapper;
    public VehiculoQueryHandler(ServicioVehiculo servicioVehiculo, IMapper mapper)
    {
        _servicioVehiculo = servicioVehiculo;
        _mapper = mapper;
    }

    public async Task<VehiculoDto> Handle(VehiculoQuery request, CancellationToken cancellationToken)
    {
        var vehiculo = await _servicioVehiculo.ConsultarVehiculoPorId(request.Id);
        return _mapper.Map<VehiculoDto>(vehiculo);
    }
}
