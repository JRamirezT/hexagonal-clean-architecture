namespace HexagonalCleanArchitecture.Dominio.Entidades.Base;

public abstract class EntidadBase
{
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; protected set; } = DateTime.UtcNow;
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
}
