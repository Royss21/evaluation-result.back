using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefrescarTokenEncriptado",
                table: "UsuarioToken",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "UsuarioToken",
                newName: "FechaExpiracionToken");

            migrationBuilder.RenameColumn(
                name: "FechaExpiracion",
                table: "UsuarioToken",
                newName: "FechaExpiracionRefrescarToken");

            migrationBuilder.AddColumn<string>(
                name: "RefrescarToken",
                table: "UsuarioToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefrescarToken",
                table: "UsuarioToken");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "UsuarioToken",
                newName: "RefrescarTokenEncriptado");

            migrationBuilder.RenameColumn(
                name: "FechaExpiracionToken",
                table: "UsuarioToken",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "FechaExpiracionRefrescarToken",
                table: "UsuarioToken",
                newName: "FechaExpiracion");
        }
    }
}
