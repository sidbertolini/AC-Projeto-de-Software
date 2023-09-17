using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AC.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PagamentoValidoAte = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Address", "Birthdate", "DataPagamento", "Name", "PagamentoValidoAte", "School", "SchoolYear" },
                values: new object[,]
                {
                    { 1, "Rua Doze, 1", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joao", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unidade 1", 2 },
                    { 2, "Rua Onze, 2", new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jose", new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unidade 2", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
