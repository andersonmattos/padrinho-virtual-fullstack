using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations.Celebrante
{
    public partial class UpdateCelebrantetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cerimonia",
                columns: table => new
                {
                    CerimoniaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CelebranteId = table.Column<int>(type: "int", nullable: false),
                    Civil = table.Column<bool>(type: "bit", nullable: false),
                    Religiosa = table.Column<bool>(type: "bit", nullable: false),
                    Local = table.Column<string>(type: "varchar(200)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cerimonia", x => x.CerimoniaId);
                    table.ForeignKey(
                        name: "FK_Cerimonia_Celebrante_CelebranteId",
                        column: x => x.CelebranteId,
                        principalTable: "Celebrante",
                        principalColumn: "CelebranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cerimonia_CelebranteId",
                table: "Cerimonia",
                column: "CelebranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cerimonia");
        }
    }
}
