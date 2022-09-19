using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations.Banda
{
    public partial class InsertBandatable : Migration
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
                    Valor = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banda", x => x.BandaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banda");
        }
    }
}
