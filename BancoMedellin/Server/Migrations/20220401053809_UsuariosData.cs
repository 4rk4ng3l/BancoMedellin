using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoMedellin.Server.Migrations
{
    public partial class UsuariosData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "Password" },
                values: new object[] { 1001m, "Daniela Fonseca", "1243" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Dni", "Nombre", "Password" },
                values: new object[] { 771185581m, "German Fonseca P", "1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Dni",
                keyValue: 1001m);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Dni",
                keyValue: 771185581m);
        }
    }
}
