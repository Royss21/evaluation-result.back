using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compania_Ubigeo_UbigeoId",
                table: "Compania");

            migrationBuilder.DropColumn(
                name: "Abreviatura",
                table: "Tamanio");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Categoria");

            migrationBuilder.RenameColumn(
                name: "Abreviatura",
                table: "Categoria",
                newName: "Codigo");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Tamanio",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "UbigeoId",
                table: "Compania",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Compania_Ubigeo_UbigeoId",
                table: "Compania",
                column: "UbigeoId",
                principalTable: "Ubigeo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compania_Ubigeo_UbigeoId",
                table: "Compania");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Categoria",
                newName: "Abreviatura");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Tamanio",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "Abreviatura",
                table: "Tamanio",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UbigeoId",
                table: "Compania",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Compania_Ubigeo_UbigeoId",
                table: "Compania",
                column: "UbigeoId",
                principalTable: "Ubigeo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
