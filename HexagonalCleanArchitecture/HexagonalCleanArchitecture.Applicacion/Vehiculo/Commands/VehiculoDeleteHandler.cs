using HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;
using MediatR;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;

public class VehiculoDeleteHandler : IRequestHandler<VehiculoDeleteCommand>
{
    readonly ServicioVehiculo _servicioVehiculo;
    public VehiculoDeleteHandler(ServicioVehiculo servicioVehiculo)
    {
        _servicioVehiculo = servicioVehiculo;
    }

    public async Task Handle(VehiculoDeleteCommand request, CancellationToken cancellationToken)
    {
        await _servicioVehiculo.EliminarVehiculo(request.Id);
    }
}
