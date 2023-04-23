using AutoMapper;
using HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;
using MediatR;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;

public class VehiculoUpdateHandler : IRequestHandler<VehiculoUpdateCommand>
{    
    private readonly IMapper _mapper;
    readonly ServicioVehiculo _servicioVehiculo;

    public VehiculoUpdateHandler(IMapper mapper, ServicioVehiculo servicioVehiculo)
    {
        _mapper = mapper;
        _servicioVehiculo = servicioVehiculo;
    }
    public async Task Handle(VehiculoUpdateCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = _mapper.Map<Dominio.Entidades.Vehiculo>(request);
        await _servicioVehiculo.ActualizarVehiculo(vehiculo);
    }
}

