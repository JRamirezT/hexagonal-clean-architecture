using MediatR;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;

public class VehiculoHandler : IRequestHandler<VehiculoCommand>
{
    public async Task Handle(VehiculoCommand request, CancellationToken cancellationToken)
    {
        
    }
}

