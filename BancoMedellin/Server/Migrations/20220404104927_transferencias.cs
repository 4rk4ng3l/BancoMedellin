using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoMedellin.Server.Migrations
{
    public partial class transferencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CuentaCredito",
                table: "Transferencias",
                column: "CuentaCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CuentaDebito",
                table: "Transferencias",
                column: "CuentaDebito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencias");
        }
    }
}
