using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations.Festa
{
    public partial class UpdateFKDefinitionsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festa",
                columns: table => new
                {
                    FestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLocal = table.Column<string>(type: "varchar(70)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    HorasContratadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festa", x => x.FestaId);
                });

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
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banda", x => x.BandaId);
                    table.ForeignKey(
                        name: "FK_Banda_Festa_FestaId",
                        column: x => x.FestaId,
                        principalTable: "Festa",
                        principalColumn: "FestaId",
                        onDelete: ReferentialAction.Cascade);
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
                    Comidas = table.Column<string>(type: "varchar(400)", nullable: false),
                    FestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffet", x => x.BuffetId);
                    table.ForeignKey(
                        name: "FK_Buffet_Festa_FestaId",
                        column: x => x.FestaId,
                        principalTable: "Festa",
                        principalColumn: "FestaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banda_FestaId",
                table: "Banda",
                column: "FestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Buffet_FestaId",
                table: "Buffet",
                column: "FestaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banda");

            migrationBuilder.DropTable(
                name: "Buffet");

            migrationBuilder.DropTable(
                name: "Festa");
        }
    }
}
