using HexagonalCleanArchitecture.Applicacion.Vehiculo.Dto;
using MediatR;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Queries;

public record VehiculoQuery(Guid Id) : IRequest<VehiculoDto>;
