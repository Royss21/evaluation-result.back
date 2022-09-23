using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class cambiosss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Imagen_ImagenId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_ImagenId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "Color");

            migrationBuilder.CreateTable(
                name: "TelaColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelaId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ImagenId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelaColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelaColor_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TelaColor_Imagen_ImagenId",
                        column: x => x.ImagenId,
                        principalTable: "Imagen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TelaColor_Tela_TelaId",
                        column: x => x.TelaId,
                        principalTable: "Tela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelaColor_ColorId",
                table: "TelaColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_TelaColor_ImagenId",
                table: "TelaColor",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_TelaColor_TelaId",
                table: "TelaColor",
                column: "TelaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelaColor");

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "Color",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ImagenId",
                table: "Color",
                column: "ImagenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Imagen_ImagenId",
                table: "Color",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
