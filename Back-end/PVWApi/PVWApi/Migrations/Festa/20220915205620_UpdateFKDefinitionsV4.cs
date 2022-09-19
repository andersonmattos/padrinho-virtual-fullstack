using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations.Festa
{
    public partial class UpdateFKDefinitionsV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banda_Festa_FestaId",
                table: "Banda");

            migrationBuilder.DropForeignKey(
                name: "FK_Buffet_Festa_FestaId",
                table: "Buffet");

            migrationBuilder.DropIndex(
                name: "IX_Buffet_FestaId",
                table: "Buffet");

            migrationBuilder.DropIndex(
                name: "IX_Banda_FestaId",
                table: "Banda");

            migrationBuilder.DropColumn(
                name: "FestaId",
                table: "Buffet");

            migrationBuilder.DropColumn(
                name: "FestaId",
                table: "Banda");

            migrationBuilder.CreateIndex(
                name: "IX_Festa_BandaId",
                table: "Festa",
                column: "BandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Festa_BuffetId",
                table: "Festa",
                column: "BuffetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Festa_Banda_BandaId",
                table: "Festa",
                column: "BandaId",
                principalTable: "Banda",
                principalColumn: "BandaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Festa_Buffet_BuffetId",
                table: "Festa",
                column: "BuffetId",
                principalTable: "Buffet",
                principalColumn: "BuffetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Festa_Banda_BandaId",
                table: "Festa");

            migrationBuilder.DropForeignKey(
                name: "FK_Festa_Buffet_BuffetId",
                table: "Festa");

            migrationBuilder.DropIndex(
                name: "IX_Festa_BandaId",
                table: "Festa");

            migrationBuilder.DropIndex(
                name: "IX_Festa_BuffetId",
                table: "Festa");

            migrationBuilder.AddColumn<int>(
                name: "FestaId",
                table: "Buffet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FestaId",
                table: "Banda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Buffet_FestaId",
                table: "Buffet",
                column: "FestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Banda_FestaId",
                table: "Banda",
                column: "FestaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banda_Festa_FestaId",
                table: "Banda",
                column: "FestaId",
                principalTable: "Festa",
                principalColumn: "FestaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buffet_Festa_FestaId",
                table: "Buffet",
                column: "FestaId",
                principalTable: "Festa",
                principalColumn: "FestaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
