using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.Api.Migrations
{
    /// <inheritdoc />
    public partial class salas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthdate", "DataPagamento", "PagamentoValidoAte", "SalaId" },
                values: new object[] { new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthdate", "DataPagamento", "PagamentoValidoAte", "SalaId" },
                values: new object[] { new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_SalaId",
                table: "Alunos",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Sala_SalaId",
                table: "Alunos",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Sala_SalaId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_SalaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Alunos");

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthdate", "DataPagamento", "PagamentoValidoAte" },
                values: new object[] { new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthdate", "DataPagamento", "PagamentoValidoAte" },
                values: new object[] { new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
