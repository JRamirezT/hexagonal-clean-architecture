using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HexagonalCleanArchitecture.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialHexagonalClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HexagonalCleanArchitecture");

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                schema: "HexagonalCleanArchitecture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<int>(type: "integer", nullable: false),
                    TipoVehiculo = table.Column<int>(type: "integer", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculo",
                schema: "HexagonalCleanArchitecture");
        }
    }
}
