using HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;
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
    public async Task CrearVehiculo(VehiculoCommand cliente) => await _mediator.Send(cliente);
}

