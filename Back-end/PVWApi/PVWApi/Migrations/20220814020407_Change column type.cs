using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations
{
    public partial class Changecolumntype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TemCasamento",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)");

            migrationBuilder.AlterColumn<int>(
                name: "CasamentoId",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TemCasamento",
                table: "Usuario",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CasamentoId",
                table: "Usuario",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
