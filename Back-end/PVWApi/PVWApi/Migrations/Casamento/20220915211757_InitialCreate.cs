using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PVWApi.Migrations.Casamento
{
    public partial class InitialCreate : Migration
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
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banda", x => x.BandaId);
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
                    Comidas = table.Column<string>(type: "varchar(400)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffet", x => x.BuffetId);
                });

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
                });

            migrationBuilder.CreateTable(
                name: "Decoracao",
                columns: table => new
                {
                    DecoracaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    Item = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decoracao", x => x.DecoracaoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(10)", nullable: false),
                    TemCasamento = table.Column<int>(type: "int", nullable: false),
                    CasamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Festa",
                columns: table => new
                {
                    FestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLocal = table.Column<string>(type: "varchar(70)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    HorasContratadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuffetId = table.Column<int>(type: "int", nullable: false),
                    BandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festa", x => x.FestaId);
                    table.ForeignKey(
                        name: "FK_Festa_Banda_BandaId",
                        column: x => x.BandaId,
                        principalTable: "Banda",
                        principalColumn: "BandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Festa_Buffet_BuffetId",
                        column: x => x.BuffetId,
                        principalTable: "Buffet",
                        principalColumn: "BuffetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casamento",
                columns: table => new
                {
                    CasamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeParceiroA = table.Column<string>(type: "varchar(70)", nullable: false),
                    NomeParceiroB = table.Column<string>(type: "varchar(70)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    UsuarioLoginId = table.Column<int>(type: "int", nullable: false),
                    FestaId = table.Column<int>(type: "int", nullable: false),
                    CerimoniaId = table.Column<int>(type: "int", nullable: false),
                    DecoracaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casamento", x => x.CasamentoId);
                    table.ForeignKey(
                        name: "FK_Casamento_Cerimonia_CerimoniaId",
                        column: x => x.CerimoniaId,
                        principalTable: "Cerimonia",
                        principalColumn: "CerimoniaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casamento_Decoracao_DecoracaoId",
                        column: x => x.DecoracaoId,
                        principalTable: "Decoracao",
                        principalColumn: "DecoracaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casamento_Festa_FestaId",
                        column: x => x.FestaId,
                        principalTable: "Festa",
                        principalColumn: "FestaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casamento_Usuario_UsuarioLoginId",
                        column: x => x.UsuarioLoginId,
                        principalTable: "Usuario",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casamento_CerimoniaId",
                table: "Casamento",
                column: "CerimoniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Casamento_DecoracaoId",
                table: "Casamento",
                column: "DecoracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Casamento_FestaId",
                table: "Casamento",
                column: "FestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Casamento_UsuarioLoginId",
                table: "Casamento",
                column: "UsuarioLoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Festa_BandaId",
                table: "Festa",
                column: "BandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Festa_BuffetId",
                table: "Festa",
                column: "BuffetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casamento");

            migrationBuilder.DropTable(
                name: "Cerimonia");

            migrationBuilder.DropTable(
                name: "Decoracao");

            migrationBuilder.DropTable(
                name: "Festa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Banda");

            migrationBuilder.DropTable(
                name: "Buffet");
        }
    }
}
