using HexagonalCleanArchitecture.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HexagonalCleanArchitecture.Infraestructura.RepositorioGenerico;

public class HexagonalContext : DbContext
{
    private readonly IConfiguration _config;

    public HexagonalContext(DbContextOptions<HexagonalContext> options, 
                            IConfiguration config) : base(options)
    {
        _config = config;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_config.GetSection("NombreEsquem").Value);
        modelBuilder.Entity<Vehiculo>();
    }
}
