using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations.Festa
{
    public partial class UpdateFKDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banda",
                columns: table => new
                {
                    BandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    NumeroMusicas = table.Column<int>(type: "int", nullable: false),
                    NumeroIntegrantes = table.Column<int>(type: "int", nullable: false),
                    HorasContratadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banda", x => x.BandaId);
                });

            migrationBuilder.CreateTable(
                name: "Buffet",
                columns: table => new
                {
                    BuffetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    HorasContratadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comidas = table.Column<string>(type: "varchar(400)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffet", x => x.BuffetId);
                });

            migrationBuilder.CreateTable(
                name: "Festa",
                columns: table => new
                {
                    FestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLocal = table.Column<string>(type: "varchar(70)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    HorasContratadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuffetId = table.Column<int>(type: "int", nullable: false),
                    BandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festa", x => x.FestaId);
                    table.ForeignKey(
                        name: "FK_Festa_Banda_BandaId",
                        column: x => x.BandaId,
                        principalTable: "Banda",
                        principalColumn: "BandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Festa_Buffet_BuffetId",
                        column: x => x.BuffetId,
                        principalTable: "Buffet",
                        principalColumn: "BuffetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Festa_BandaId",
                table: "Festa",
                column: "BandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Festa_BuffetId",
                table: "Festa",
                column: "BuffetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Festa");

            migrationBuilder.DropTable(
                name: "Banda");

            migrationBuilder.DropTable(
                name: "Buffet");
        }
    }
}
