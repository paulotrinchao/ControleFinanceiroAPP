using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controlefinanceiro.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "SaldosDiarios",
                columns: table => new
                {
                    SaldoDiarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaldoInicial = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TotalCredito = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TotalDebito = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldosDiarios", x => x.SaldoDiarioId);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    LancamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.LancamentoId);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_CategoriaId",
                table: "Lancamentos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SaldosDiarios_Data",
                table: "SaldosDiarios",
                column: "Data",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "SaldosDiarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
