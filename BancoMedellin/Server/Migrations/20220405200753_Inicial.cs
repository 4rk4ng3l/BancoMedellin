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

            migrationBuilder.CreateTable(
                name: "Autorizadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioDni = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorizadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autorizadas_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autorizadas_Usuarios_UsuarioDni",
                        column: x => x.UsuarioDni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni");
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioDni = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CuentaCredito = table.Column<int>(type: "int", nullable: false),
                    CuentaDebito = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencias_Cuentas_CuentaCredito",
                        column: x => x.CuentaCredito,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencias_Cuentas_CuentaDebito",
                        column: x => x.CuentaDebito,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencias_Usuarios_UsuarioDni",
                        column: x => x.UsuarioDni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
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
                values: new object[] { 77185581m, "German Fonseca P", "1234", 0m });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "Id", "Balance", "NombreCuenta", "UsuarioDni" },
                values: new object[,]
                {
                    { 1, 50000m, "Vivienda", 77185581m },
                    { 2, 90000m, "Vehiculo", 77185581m },
                    { 3, 90000m, "Universidad", 1001m },
                    { 4, 70000m, "Excursion", 1001m },
                    { 5, 170000m, "España", 1002m }
                });

            migrationBuilder.InsertData(
                table: "Autorizadas",
                columns: new[] { "Id", "CuentaId", "UsuarioDni" },
                values: new object[,]
                {
                    { 1, 3, 77185581m },
                    { 2, 4, 77185581m },
                    { 3, 1, 1001m },
                    { 4, 2, 1001m }
                });

            migrationBuilder.InsertData(
                table: "Transferencias",
                columns: new[] { "Id", "CuentaCredito", "CuentaDebito", "UsuarioDni", "Valor" },
                values: new object[] { 1, 2, 1, 77185581m, 30000m });

            migrationBuilder.CreateIndex(
                name: "IX_Autorizadas_CuentaId",
                table: "Autorizadas",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Autorizadas_UsuarioDni",
                table: "Autorizadas",
                column: "UsuarioDni");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioDni",
                table: "Cuentas",
                column: "UsuarioDni");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CuentaCredito",
                table: "Transferencias",
                column: "CuentaCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CuentaDebito",
                table: "Transferencias",
                column: "CuentaDebito");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_UsuarioDni",
                table: "Transferencias",
                column: "UsuarioDni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autorizadas");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
