using AutoMapper;
using HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;
using MediatR;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;

public class VehiculoHandler : IRequestHandler<VehiculoCommand>
{
    private readonly IMapper _mapper;
    readonly ServicioVehiculo _servicioVehiculo;

    public VehiculoHandler(IMapper mapper, ServicioVehiculo servicioVehiculo)
    {
        _mapper = mapper;
        _servicioVehiculo = servicioVehiculo;
    }

    public Task Handle(VehiculoCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = _mapper.Map<Dominio.Entidades.Vehiculo>(request);
        _servicioVehiculo.GuardarVehiculo(vehiculo);
        return Task.CompletedTask;
    }
}
