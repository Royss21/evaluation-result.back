using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class cambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagen_Compania_CompaniaId",
                table: "Imagen");

            migrationBuilder.DropIndex(
                name: "IX_Imagen_CompaniaId",
                table: "Imagen");

            migrationBuilder.DropColumn(
                name: "CompaniaId",
                table: "Imagen");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenLogoId",
                table: "Compania",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Compania_ImagenLogoId",
                table: "Compania",
                column: "ImagenLogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compania_Imagen_ImagenLogoId",
                table: "Compania",
                column: "ImagenLogoId",
                principalTable: "Imagen",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compania_Imagen_ImagenLogoId",
                table: "Compania");

            migrationBuilder.DropIndex(
                name: "IX_Compania_ImagenLogoId",
                table: "Compania");

            migrationBuilder.AddColumn<Guid>(
                name: "CompaniaId",
                table: "Imagen",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ImagenLogoId",
                table: "Compania",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imagen_CompaniaId",
                table: "Imagen",
                column: "CompaniaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagen_Compania_CompaniaId",
                table: "Imagen",
                column: "CompaniaId",
                principalTable: "Compania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
