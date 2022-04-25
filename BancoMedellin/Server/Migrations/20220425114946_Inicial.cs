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
                    Dni = table.Column<int>(type: "int", nullable: false),
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
                    UsuarioDni = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<long>(type: "bigint", nullable: false),
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
                    UsuarioDni = table.Column<int>(type: "int", nullable: false),
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
                    UsuarioDni = table.Column<int>(type: "int", nullable: false),
                    CuentaCredito = table.Column<int>(type: "int", nullable: false),
                    CuentaDebito = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<long>(type: "bigint", nullable: false),
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
                values: new object[] { 11111, "Daniela Fonseca", new byte[] { 239, 190, 185, 51, 12, 68, 64, 175, 36, 44, 248, 164, 163, 94, 240, 85, 143, 7, 144, 7, 126, 136, 202, 224, 126, 24, 43, 58, 72, 115, 63, 131, 219, 200, 157, 238, 87, 243, 157, 211, 65, 177, 127, 158, 130, 24, 155, 164, 248, 183, 241, 190, 6, 49, 237, 22, 34, 97, 28, 253, 139, 22, 121, 18 }, new byte[] { 6, 125, 78, 31, 90, 58, 50, 120, 135, 235, 24, 138, 50, 65, 241, 114, 86, 150, 215, 184, 81, 252, 252, 103, 171, 39, 105, 78, 7, 221, 235, 244, 226, 26, 48, 87, 235, 156, 28, 67, 94, 39, 131, 146, 101, 12, 148, 125, 183, 113, 150, 225, 11, 95, 236, 50, 136, 81, 151, 220, 177, 65, 199, 11, 13, 7, 93, 206, 200, 74, 3, 211, 206, 110, 84, 5, 141, 125, 106, 245, 216, 49, 77, 17, 61, 65, 29, 112, 102, 189, 30, 81, 158, 52, 88, 240, 240, 188, 4, 252, 252, 14, 2, 218, 219, 218, 130, 149, 36, 8, 37, 73, 23, 45, 48, 136, 176, 64, 156, 252, 202, 70, 156, 209, 254, 130, 124, 254 } });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "PasswordHash", "PasswordSalt" },
                values: new object[] { 22222, "Juan Sebastian Fonseca", new byte[] { 241, 34, 109, 122, 12, 226, 22, 193, 44, 77, 165, 127, 119, 81, 130, 100, 131, 87, 75, 216, 62, 224, 18, 190, 220, 79, 208, 158, 198, 60, 246, 169, 154, 82, 224, 147, 176, 52, 50, 225, 78, 27, 81, 143, 144, 64, 147, 125, 126, 56, 13, 230, 147, 180, 29, 47, 68, 201, 183, 37, 63, 65, 70, 97 }, new byte[] { 229, 161, 11, 41, 170, 116, 239, 105, 40, 81, 246, 240, 231, 170, 170, 182, 35, 24, 251, 216, 194, 220, 201, 210, 1, 49, 216, 118, 176, 153, 131, 104, 22, 189, 223, 30, 82, 135, 143, 140, 122, 201, 214, 90, 123, 90, 38, 193, 55, 226, 162, 56, 237, 43, 251, 162, 58, 114, 143, 34, 150, 248, 53, 200, 207, 196, 187, 248, 208, 189, 130, 233, 133, 195, 195, 47, 179, 47, 182, 182, 63, 116, 226, 31, 224, 251, 228, 45, 34, 240, 213, 243, 119, 115, 7, 149, 4, 114, 59, 233, 54, 249, 212, 178, 220, 37, 49, 37, 214, 12, 231, 101, 41, 235, 147, 92, 168, 17, 100, 65, 248, 87, 19, 120, 180, 72, 78, 45 } });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "PasswordHash", "PasswordSalt" },
                values: new object[] { 77185581, "German Fonseca P", new byte[] { 31, 221, 243, 246, 208, 120, 146, 193, 189, 45, 49, 157, 244, 229, 253, 212, 224, 230, 205, 159, 219, 145, 211, 69, 107, 59, 223, 150, 86, 241, 61, 149, 67, 249, 34, 122, 234, 45, 137, 29, 8, 181, 5, 220, 77, 14, 228, 50, 251, 174, 96, 26, 240, 22, 22, 224, 243, 124, 56, 103, 115, 65, 167, 79 }, new byte[] { 240, 220, 214, 84, 201, 20, 249, 192, 114, 18, 1, 209, 175, 3, 3, 154, 77, 3, 237, 156, 55, 106, 84, 93, 117, 174, 249, 99, 245, 20, 25, 50, 230, 192, 75, 122, 172, 134, 223, 202, 172, 70, 139, 120, 48, 213, 226, 19, 155, 116, 94, 236, 160, 152, 169, 172, 125, 188, 118, 205, 89, 110, 77, 194, 114, 176, 124, 102, 204, 49, 10, 136, 0, 9, 241, 57, 40, 173, 65, 208, 59, 11, 253, 154, 153, 195, 15, 179, 42, 213, 222, 223, 25, 127, 26, 45, 104, 61, 194, 135, 6, 146, 54, 206, 242, 104, 237, 187, 106, 62, 2, 139, 188, 244, 121, 215, 50, 75, 187, 200, 198, 219, 178, 101, 74, 53, 38, 167 } });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "Id", "Balance", "NombreCuenta", "UsuarioDni" },
                values: new object[,]
                {
                    { 1, 50000L, "Vivienda", 77185581 },
                    { 2, 90000L, "Vehiculo", 77185581 },
                    { 3, 90000L, "Universidad", 11111 },
                    { 4, 70000L, "Excursion", 11111 },
                    { 5, 170000L, "España", 22222 }
                });

            migrationBuilder.InsertData(
                table: "Autorizadas",
                columns: new[] { "Id", "CuentaId", "UsuarioDni" },
                values: new object[,]
                {
                    { 1, 3, 77185581 },
                    { 2, 4, 77185581 },
                    { 3, 1, 11111 },
                    { 4, 2, 11111 }
                });

            migrationBuilder.InsertData(
                table: "Transferencias",
                columns: new[] { "Id", "CuentaCredito", "CuentaDebito", "UsuarioDni", "Valor" },
                values: new object[] { 1, 2, 1, 77185581, 30000L });

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
