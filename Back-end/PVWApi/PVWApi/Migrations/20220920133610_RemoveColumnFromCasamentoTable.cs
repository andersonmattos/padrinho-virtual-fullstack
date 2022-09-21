using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations
{
    public partial class RemoveColumnFromCasamentoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConvidadoId",
                table: "Casamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConvidadoId",
                table: "Casamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
