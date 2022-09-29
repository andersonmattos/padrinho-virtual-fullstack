using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations
{
    public partial class AddGetRouteToConvidado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convidado_Casamento_CasamentoId",
                table: "Convidado");

            migrationBuilder.AlterColumn<int>(
                name: "CasamentoId",
                table: "Convidado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "CasamentoId",
                table: "Convidado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Convidado_Casamento_CasamentoId",
                table: "Convidado",
                column: "CasamentoId",
                principalTable: "Casamento",
                principalColumn: "CasamentoId");
        }
    }
}
