using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banco.Repositorio.Sql.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncodedKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoDeNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ahorro",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Encodedkey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteEncodedkey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteEntidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ahorro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ahorro_Cliente_ClienteEntidadId",
                        column: x => x.ClienteEntidadId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncodedKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Canal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AhorroId = table.Column<int>(type: "int", nullable: false),
                    AhorroEncodedkey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AhorroEntidadId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Ahorro_AhorroEntidadId",
                        column: x => x.AhorroEntidadId,
                        principalTable: "Ahorro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ahorro_ClienteEntidadId",
                table: "Ahorro",
                column: "ClienteEntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_AhorroEntidadId",
                table: "Movimiento",
                column: "AhorroEntidadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Ahorro");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
