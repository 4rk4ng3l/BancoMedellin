using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoMedellin.Server.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Dni = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    UsuarioDni = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioDni = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_UsuarioDni",
                        column: x => x.UsuarioDni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "Password", "UsuarioDni" },
                values: new object[] { 1001m, "Daniela Fonseca", "1243", 0m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "Password", "UsuarioDni" },
                values: new object[] { 1002m, "Juan Sebastian Fonseca", "1244", 0m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "Password", "UsuarioDni" },
                values: new object[] { 771185581m, "German Fonseca P", "1234", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioDni",
                table: "Cuentas",
                column: "UsuarioDni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
