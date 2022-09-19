using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations.Buffet
{
    public partial class AddingFkReference : Migration
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
                    FkBandaId = table.Column<int>(type: "int", nullable: false),
                    FkBuffetId = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    HorasContratadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuffetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festa", x => x.FestaId);
                    table.ForeignKey(
                        name: "FK_Festa_Buffet_BuffetId",
                        column: x => x.BuffetId,
                        principalTable: "Buffet",
                        principalColumn: "BuffetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Festa_BuffetId",
                table: "Festa",
                column: "BuffetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Festa");
        }
    }
}
