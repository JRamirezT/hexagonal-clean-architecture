using HexagonalCleanArchitecture.Dominio.Enumerados;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HexagonalCleanArchitecture.Applicacion.Vehiculo.Commands;

public record VehiculoUpdateCommand(

    [Required]
    Guid Id,

    [Required]
    [StringLength(100, ErrorMessage = "{0} La marca debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
    string Marca,

    [Required]
    [StringLength(100, ErrorMessage = "{0} El color debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
    string Color,

    [Required]
    int Modelo,

    TipoVehiculo TipoVehiculo
) : IRequest;
