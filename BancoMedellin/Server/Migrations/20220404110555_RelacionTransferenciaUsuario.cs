using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoMedellin.Server.Migrations
{
    public partial class RelacionTransferenciaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_UsuarioDni",
                table: "Transferencias",
                column: "UsuarioDni");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Usuarios_UsuarioDni",
                table: "Transferencias",
                column: "UsuarioDni",
                principalTable: "Usuarios",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Usuarios_UsuarioDni",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_UsuarioDni",
                table: "Transferencias");
        }
    }
}
