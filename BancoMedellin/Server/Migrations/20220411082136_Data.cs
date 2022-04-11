using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoMedellin.Server.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Dni = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
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
                columns: new[] { "Dni", "Nombre", "PasswordHash", "PasswordSalt" },
                values: new object[] { 11111m, "Daniela Fonseca", new byte[] { 124, 143, 35, 142, 52, 81, 189, 83, 179, 21, 117, 100, 75, 180, 127, 9, 133, 244, 129, 64, 246, 44, 81, 29, 80, 82, 34, 163, 171, 209, 53, 39, 236, 244, 225, 150, 249, 195, 57, 194, 42, 134, 244, 84, 176, 251, 239, 228, 227, 206, 70, 188, 175, 202, 45, 125, 159, 95, 218, 150, 208, 212, 242, 150 }, new byte[] { 46, 232, 37, 253, 215, 47, 91, 252, 167, 227, 255, 61, 144, 158, 155, 164, 140, 209, 201, 97, 188, 14, 83, 254, 15, 3, 211, 84, 70, 124, 26, 54, 52, 67, 47, 192, 96, 252, 212, 246, 253, 12, 151, 65, 104, 78, 218, 69, 145, 64, 204, 211, 223, 75, 250, 169, 111, 1, 166, 234, 131, 96, 5, 126, 122, 6, 227, 232, 117, 184, 208, 197, 21, 63, 151, 125, 73, 123, 61, 67, 160, 94, 96, 27, 244, 153, 130, 212, 249, 31, 86, 243, 240, 71, 17, 246, 73, 26, 15, 25, 218, 203, 2, 89, 76, 85, 146, 85, 222, 154, 20, 62, 155, 231, 229, 226, 191, 88, 215, 90, 140, 246, 44, 0, 244, 235, 99, 51 } });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "PasswordHash", "PasswordSalt" },
                values: new object[] { 22222m, "Juan Sebastian Fonseca", new byte[] { 142, 143, 28, 233, 26, 251, 202, 198, 233, 87, 38, 42, 169, 8, 90, 180, 10, 20, 251, 181, 228, 126, 168, 145, 32, 175, 244, 193, 211, 202, 232, 216, 107, 63, 107, 237, 103, 145, 251, 21, 150, 38, 84, 130, 33, 79, 115, 250, 254, 91, 131, 53, 64, 19, 32, 179, 152, 99, 252, 184, 36, 207, 12, 153 }, new byte[] { 219, 250, 93, 171, 55, 176, 73, 196, 55, 226, 115, 206, 33, 158, 42, 127, 48, 13, 234, 144, 148, 22, 123, 62, 79, 181, 103, 152, 143, 171, 158, 43, 33, 34, 156, 247, 106, 101, 92, 217, 23, 153, 167, 149, 79, 34, 156, 222, 225, 37, 119, 51, 137, 60, 119, 165, 86, 66, 55, 8, 144, 186, 208, 242, 189, 212, 89, 168, 58, 242, 150, 131, 30, 36, 127, 151, 224, 174, 107, 45, 86, 170, 144, 17, 235, 4, 163, 97, 45, 214, 190, 184, 221, 189, 192, 27, 72, 58, 232, 95, 2, 163, 73, 102, 93, 246, 62, 240, 165, 112, 101, 141, 32, 145, 1, 63, 45, 242, 231, 10, 147, 253, 81, 102, 44, 105, 53, 109 } });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "PasswordHash", "PasswordSalt" },
                values: new object[] { 77185581m, "German Fonseca P", new byte[] { 197, 190, 101, 27, 190, 140, 194, 228, 11, 195, 169, 170, 18, 141, 127, 137, 103, 114, 213, 150, 3, 72, 171, 125, 193, 49, 172, 7, 59, 161, 51, 129, 112, 62, 38, 166, 247, 233, 152, 82, 84, 134, 227, 182, 82, 86, 34, 30, 31, 34, 67, 161, 155, 41, 81, 99, 206, 131, 46, 123, 62, 238, 240, 65 }, new byte[] { 150, 78, 213, 227, 116, 111, 91, 207, 12, 13, 147, 223, 95, 85, 227, 46, 173, 241, 219, 98, 129, 123, 153, 97, 84, 76, 187, 216, 107, 193, 176, 231, 39, 55, 233, 224, 202, 248, 52, 15, 160, 86, 242, 164, 109, 28, 203, 200, 2, 151, 182, 19, 249, 52, 160, 72, 58, 165, 63, 146, 106, 197, 22, 22, 231, 238, 153, 223, 107, 214, 85, 23, 12, 56, 153, 197, 170, 94, 238, 14, 247, 102, 187, 62, 99, 165, 115, 201, 167, 92, 114, 33, 44, 147, 61, 165, 109, 179, 244, 81, 43, 14, 113, 224, 253, 149, 48, 205, 25, 145, 3, 127, 169, 230, 209, 111, 0, 55, 17, 105, 247, 3, 100, 23, 231, 124, 129, 98 } });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "Id", "Balance", "NombreCuenta", "UsuarioDni" },
                values: new object[,]
                {
                    { 1, 50000m, "Vivienda", 77185581m },
                    { 2, 90000m, "Vehiculo", 77185581m },
                    { 3, 90000m, "Universidad", 11111m },
                    { 4, 70000m, "Excursion", 11111m },
                    { 5, 170000m, "España", 22222m }
                });

            migrationBuilder.InsertData(
                table: "Autorizadas",
                columns: new[] { "Id", "CuentaId", "UsuarioDni" },
                values: new object[,]
                {
                    { 1, 3, 77185581m },
                    { 2, 4, 77185581m },
                    { 3, 1, 11111m },
                    { 4, 2, 11111m }
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
