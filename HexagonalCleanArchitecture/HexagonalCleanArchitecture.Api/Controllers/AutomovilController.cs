using HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;
using HexagonalCleanArchitecture.Applicacion.Vehiculo.Dto;
using HexagonalCleanArchitecture.Applicacion.Vehiculo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalCleanArchitecture.Api.Controllers;

[Route("api/automovil")]
[ApiController]
public class AutomovilController : ControllerBase
{
    readonly IMediator _mediator;

    public AutomovilController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task CrearAutomovil(VehiculoCommand vehiculo) => await _mediator.Send(vehiculo);

    [HttpGet]
    public async Task<VehiculoDto> ObtenerAutomovilPorId(Guid Id) => await _mediator.Send(new VehiculoQuery(Id));

    [HttpPut]
    public async Task Actualizar(VehiculoUpdateCommand vehiculo) => await _mediator.Send(vehiculo);

    [HttpDelete]
    public async Task Eliminar(Guid Id) => await _mediator.Send(new VehiculoDeleteCommand(Id));
}
