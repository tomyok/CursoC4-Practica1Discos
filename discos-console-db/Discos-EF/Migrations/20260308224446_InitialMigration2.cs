using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discos_EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estilos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEdiciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEdiciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadCanciones = table.Column<int>(type: "int", nullable: false),
                    UrlTapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstiloId = table.Column<int>(type: "int", nullable: true),
                    TipoEdicionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discos_Estilos_EstiloId",
                        column: x => x.EstiloId,
                        principalTable: "Estilos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discos_TipoEdiciones_TipoEdicionId",
                        column: x => x.TipoEdicionId,
                        principalTable: "TipoEdiciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discos_EstiloId",
                table: "Discos",
                column: "EstiloId");

            migrationBuilder.CreateIndex(
                name: "IX_Discos_TipoEdicionId",
                table: "Discos",
                column: "TipoEdicionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discos");

            migrationBuilder.DropTable(
                name: "Estilos");

            migrationBuilder.DropTable(
                name: "TipoEdiciones");
        }
    }
}
