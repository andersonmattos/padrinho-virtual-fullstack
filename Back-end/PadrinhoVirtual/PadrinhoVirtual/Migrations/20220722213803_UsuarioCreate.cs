using Microsoft.EntityFrameworkCore.Migrations;

namespace PadrinhoVirtual.Migrations
{
    public partial class UsuarioCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuario",
                type: "varchar(70)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "LoginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "LoginId");
        }
    }
}
