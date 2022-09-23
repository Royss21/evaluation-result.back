using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class Actualizaciontablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTabla = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LlaveValores = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ValoresAntiguos = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ValoresNuevos = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoIdentidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoIdentidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcaVehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaVehiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuPadreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_MenuPadreId",
                        column: x => x.MenuPadreId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperadoraTelefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperadoraTelefono", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEntidadEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEntidadEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubigeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoUbigeo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubigeo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolMenu_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEntidadEstadoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estado_TipoEntidadEstado_TipoEntidadEstadoId",
                        column: x => x.TipoEntidadEstadoId,
                        principalTable: "TipoEntidadEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compania",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UbigeoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Movil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RutaLogo = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Host = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compania_Ubigeo_UbigeoId",
                        column: x => x.UbigeoId,
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentoIdentidadId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaNacimiento = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UbigeoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_DocumentoIdentidad_DocumentoIdentidadId",
                        column: x => x.DocumentoIdentidadId,
                        principalTable: "DocumentoIdentidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Ubigeo_UbigeoId",
                        column: x => x.UbigeoId,
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Color_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaPago_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoSunat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsSetProducto = table.Column<bool>(type: "bit", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tamanio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tamanio_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsTematica = table.Column<bool>(type: "bit", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tela_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonaTelefono",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperadoraTelefonoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaTelefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaTelefono_OperadoraTelefono_OperadoraTelefonoId",
                        column: x => x.OperadoraTelefonoId,
                        principalTable: "OperadoraTelefono",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaTelefono_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repartidor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartidor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repartidor_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repartidor_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoHash = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EsBloqueado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Compania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "Compania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoCategoria_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreReal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoFoto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoSet_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoSet_Producto_ProductoItemId",
                        column: x => x.ProductoItemId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoPrecio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TamanioId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "money", nullable: false),
                    PrecioConfeccion = table.Column<decimal>(type: "money", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPrecio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoPrecio_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoPrecio_Tamanio_TamanioId",
                        column: x => x.TamanioId,
                        principalTable: "Tamanio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteDireccionEnvio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UbigeoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsPredeterminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteDireccionEnvio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteDireccionEnvio_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteDireccionEnvio_Ubigeo_UbigeoId",
                        column: x => x.UbigeoId,
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepartidorPrecio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepartidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbigeosId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepartidorPrecio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepartidorPrecio_Repartidor_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepartidorVehiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepartidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false),
                    MarcaVehiculoId = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepartidorVehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepartidorVehiculo_MarcaVehiculo_MarcaVehiculoId",
                        column: x => x.MarcaVehiculoId,
                        principalTable: "MarcaVehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepartidorVehiculo_Repartidor_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepartidorVehiculo_TipoVehiculo_TipoVehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalTable: "TipoVehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAccesoEnpoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RutaEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAccesoEnpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioAccesoEnpoint_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefrescarTokenEncriptado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioToken_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteDireccionEnvioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UbigeoId = table.Column<int>(type: "int", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepartidorVehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    Subtotal = table.Column<decimal>(type: "money", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "money", nullable: false),
                    PrecioEnvio = table.Column<decimal>(type: "money", nullable: false),
                    EsPedidoPagado = table.Column<bool>(type: "bit", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_ClienteDireccionEnvio_ClienteDireccionEnvioId",
                        column: x => x.ClienteDireccionEnvioId,
                        principalTable: "ClienteDireccionEnvio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_RepartidorVehiculo_RepartidorVehiculoId",
                        column: x => x.RepartidorVehiculoId,
                        principalTable: "RepartidorVehiculo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_Ubigeo_UbigeoId",
                        column: x => x.UbigeoId,
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoCuota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaPagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MontoDeposito = table.Column<decimal>(type: "money", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "money", nullable: false),
                    ComprobanteImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCuota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoCuota_FormaPago_FormaPagoId",
                        column: x => x.FormaPagoId,
                        principalTable: "FormaPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoCuota_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TematicaId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    NombreBordado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "money", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "money", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "money", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    EsAdicional = table.Column<bool>(type: "bit", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_Tela_TematicaId",
                        column: x => x.TematicaId,
                        principalTable: "Tela",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidoHistorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCrea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCrea = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuarioEdita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEdita = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EsEliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoHistorial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoHistorial_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoHistorial_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_CompaniaId",
                table: "Categoria",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CompaniaId",
                table: "Cliente",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PersonaId",
                table: "Cliente",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDireccionEnvio_ClienteId",
                table: "ClienteDireccionEnvio",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDireccionEnvio_UbigeoId",
                table: "ClienteDireccionEnvio",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_CompaniaId",
                table: "Color",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compania_Correo",
                table: "Compania",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compania_UbigeoId",
                table: "Compania",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_TipoEntidadEstadoId",
                table: "Estado",
                column: "TipoEntidadEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPago_CompaniaId",
                table: "FormaPago",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuPadreId",
                table: "Menu",
                column: "MenuPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteDireccionEnvioId",
                table: "Pedido",
                column: "ClienteDireccionEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EstadoId",
                table: "Pedido",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_RepartidorVehiculoId",
                table: "Pedido",
                column: "RepartidorVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UbigeoId",
                table: "Pedido",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCuota_FormaPagoId",
                table: "PedidoCuota",
                column: "FormaPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCuota_PedidoId",
                table: "PedidoCuota",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_ColorId",
                table: "PedidoDetalle",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_PedidoId",
                table: "PedidoDetalle",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_ProductoId",
                table: "PedidoDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_TematicaId",
                table: "PedidoDetalle",
                column: "TematicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoHistorial_EstadoId",
                table: "PedidoHistorial",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoHistorial_PedidoId",
                table: "PedidoHistorial",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Correo",
                table: "Persona",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_DocumentoIdentidadId",
                table: "Persona",
                column: "DocumentoIdentidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_UbigeoId",
                table: "Persona",
                column: "UbigeoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTelefono_OperadoraTelefonoId",
                table: "PersonaTelefono",
                column: "OperadoraTelefonoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTelefono_PersonaId",
                table: "PersonaTelefono",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CompaniaId",
                table: "Producto",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCategoria_CategoriaId",
                table: "ProductoCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCategoria_ProductoId",
                table: "ProductoCategoria",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFoto_ProductoId",
                table: "ProductoFoto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPrecio_ProductoId",
                table: "ProductoPrecio",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPrecio_TamanioId",
                table: "ProductoPrecio",
                column: "TamanioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoSet_ProductoId",
                table: "ProductoSet",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoSet_ProductoItemId",
                table: "ProductoSet",
                column: "ProductoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartidor_CompaniaId",
                table: "Repartidor",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Repartidor_PersonaId",
                table: "Repartidor",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepartidorPrecio_RepartidorId",
                table: "RepartidorPrecio",
                column: "RepartidorId");

            migrationBuilder.CreateIndex(
                name: "IX_RepartidorVehiculo_MarcaVehiculoId",
                table: "RepartidorVehiculo",
                column: "MarcaVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_RepartidorVehiculo_RepartidorId",
                table: "RepartidorVehiculo",
                column: "RepartidorId");

            migrationBuilder.CreateIndex(
                name: "IX_RepartidorVehiculo_TipoVehiculoId",
                table: "RepartidorVehiculo",
                column: "TipoVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolMenu_MenuId",
                table: "RolMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RolMenu_RolId",
                table: "RolMenu",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Tamanio_CompaniaId",
                table: "Tamanio",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tela_CompaniaId",
                table: "Tela",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CompaniaId",
                table: "Usuario",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PersonaId",
                table: "Usuario",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAccesoEnpoint_UsuarioId",
                table: "UsuarioAccesoEnpoint",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_RolId",
                table: "UsuarioRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_UsuarioId",
                table: "UsuarioRol",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioToken_UsuarioId",
                table: "UsuarioToken",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "PedidoCuota");

            migrationBuilder.DropTable(
                name: "PedidoDetalle");

            migrationBuilder.DropTable(
                name: "PedidoHistorial");

            migrationBuilder.DropTable(
                name: "PersonaRol");

            migrationBuilder.DropTable(
                name: "PersonaTelefono");

            migrationBuilder.DropTable(
                name: "ProductoCategoria");

            migrationBuilder.DropTable(
                name: "ProductoFoto");

            migrationBuilder.DropTable(
                name: "ProductoPrecio");

            migrationBuilder.DropTable(
                name: "ProductoSet");

            migrationBuilder.DropTable(
                name: "RepartidorPrecio");

            migrationBuilder.DropTable(
                name: "RolMenu");

            migrationBuilder.DropTable(
                name: "UsuarioAccesoEnpoint");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "UsuarioToken");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Tela");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "OperadoraTelefono");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Tamanio");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "ClienteDireccionEnvio");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "RepartidorVehiculo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoEntidadEstado");

            migrationBuilder.DropTable(
                name: "MarcaVehiculo");

            migrationBuilder.DropTable(
                name: "Repartidor");

            migrationBuilder.DropTable(
                name: "TipoVehiculo");

            migrationBuilder.DropTable(
                name: "Compania");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "DocumentoIdentidad");

            migrationBuilder.DropTable(
                name: "Ubigeo");
        }
    }
}
