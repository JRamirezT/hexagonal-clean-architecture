using MediatR;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;

public record VehiculoDeleteCommand(Guid Id) : IRequest;
