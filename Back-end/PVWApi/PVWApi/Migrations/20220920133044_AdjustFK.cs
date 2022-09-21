using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations
{
    public partial class AdjustFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasamentoConvidado");

            migrationBuilder.CreateIndex(
                name: "IX_Convidado_CasamentoId",
                table: "Convidado",
                column: "CasamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convidado_Casamento_CasamentoId",
                table: "Convidado",
                column: "CasamentoId",
                principalTable: "Casamento",
                principalColumn: "CasamentoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convidado_Casamento_CasamentoId",
                table: "Convidado");

            migrationBuilder.DropIndex(
                name: "IX_Convidado_CasamentoId",
                table: "Convidado");

            migrationBuilder.CreateTable(
                name: "CasamentoConvidado",
                columns: table => new
                {
                    CasamentoId = table.Column<int>(type: "int", nullable: false),
                    ConvidadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasamentoConvidado", x => new { x.CasamentoId, x.ConvidadoId });
                    table.ForeignKey(
                        name: "FK_CasamentoConvidado_Casamento_CasamentoId",
                        column: x => x.CasamentoId,
                        principalTable: "Casamento",
                        principalColumn: "CasamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasamentoConvidado_Convidado_ConvidadoId",
                        column: x => x.ConvidadoId,
                        principalTable: "Convidado",
                        principalColumn: "ConvidadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasamentoConvidado_ConvidadoId",
                table: "CasamentoConvidado",
                column: "ConvidadoId");
        }
    }
}
