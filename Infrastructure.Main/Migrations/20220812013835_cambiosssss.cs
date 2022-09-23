using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class cambiosssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompaniaId",
                table: "TipoVehiculo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompaniaId",
                table: "OperadoraTelefono",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompaniaId",
                table: "MarcaVehiculo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TipoVehiculo_CompaniaId",
                table: "TipoVehiculo",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_OperadoraTelefono_CompaniaId",
                table: "OperadoraTelefono",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaVehiculo_CompaniaId",
                table: "MarcaVehiculo",
                column: "CompaniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarcaVehiculo_Compania_CompaniaId",
                table: "MarcaVehiculo",
                column: "CompaniaId",
                principalTable: "Compania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperadoraTelefono_Compania_CompaniaId",
                table: "OperadoraTelefono",
                column: "CompaniaId",
                principalTable: "Compania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoVehiculo_Compania_CompaniaId",
                table: "TipoVehiculo",
                column: "CompaniaId",
                principalTable: "Compania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarcaVehiculo_Compania_CompaniaId",
                table: "MarcaVehiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_OperadoraTelefono_Compania_CompaniaId",
                table: "OperadoraTelefono");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoVehiculo_Compania_CompaniaId",
                table: "TipoVehiculo");

            migrationBuilder.DropIndex(
                name: "IX_TipoVehiculo_CompaniaId",
                table: "TipoVehiculo");

            migrationBuilder.DropIndex(
                name: "IX_OperadoraTelefono_CompaniaId",
                table: "OperadoraTelefono");

            migrationBuilder.DropIndex(
                name: "IX_MarcaVehiculo_CompaniaId",
                table: "MarcaVehiculo");

            migrationBuilder.DropColumn(
                name: "CompaniaId",
                table: "TipoVehiculo");

            migrationBuilder.DropColumn(
                name: "CompaniaId",
                table: "OperadoraTelefono");

            migrationBuilder.DropColumn(
                name: "CompaniaId",
                table: "MarcaVehiculo");
        }
    }
}
