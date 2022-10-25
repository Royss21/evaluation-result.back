using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class migracionuno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    NewValues = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndpointService",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gerency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    MenuDadId = table.Column<int>(type: "int", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_MenuDadId",
                        column: x => x.MenuDadId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TypeHash = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GerencyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Gerency_GerencyId",
                        column: x => x.GerencyId,
                        principalTable: "Gerency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabelDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RealValue = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MinimunValue = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MaximunValue = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelDetail_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchy_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMenu_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEndpointLocked",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndpointServicetId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndpointServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEndpointLocked", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEndpointLocked_EndpointService_EndpointServiceId",
                        column: x => x.EndpointServiceId,
                        principalTable: "EndpointService",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEndpointLocked_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subcomponent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcomponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcomponent_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subcomponent_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    HierarchyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Charge_Hierarchy_HierarchyId",
                        column: x => x.HierarchyId,
                        principalTable: "Hierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HierarchyComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HierarchyId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchyComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HierarchyComponent_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HierarchyComponent_Hierarchy_HierarchyId",
                        column: x => x.HierarchyId,
                        principalTable: "Hierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationComponent_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationComponent_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationStage_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationStage_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conduct",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    SubcomponentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conduct_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conduct_Subcomponent_SubcomponentId",
                        column: x => x.SubcomponentId,
                        principalTable: "Subcomponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChargeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEgress = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborator_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubcomponentValue",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubcomponentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChargeId = table.Column<int>(type: "int", nullable: true),
                    RelativeWeight = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MinimunPercentage = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MaximunPercentage = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcomponentValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubcomponentValue_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubcomponentValue_Subcomponent_SubcomponentId",
                        column: x => x.SubcomponentId,
                        principalTable: "Subcomponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationComponentId = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentStage_EvaluationComponent_EvaluationComponentId",
                        column: x => x.EvaluationComponentId,
                        principalTable: "EvaluationComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentStage_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCollaborator",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EvaluationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollaboratorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GerencyId = table.Column<int>(type: "int", nullable: false),
                    ChargeId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    HierarchyId = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCollaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Gerency_GerencyId",
                        column: x => x.GerencyId,
                        principalTable: "Gerency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Hierarchy_HierarchyId",
                        column: x => x.HierarchyId,
                        principalTable: "Hierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaborator",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EvaluationComponentId = table.Column<int>(type: "int", nullable: false),
                    EvaluationCollaboratorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HierarchyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeightHierarchy = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    SurplusSubtotal = table.Column<decimal>(type: "money", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    TotalCalibrated = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Surplus = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CommentCollaborator = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                        column: x => x.EvaluationCollaboratorId,
                        principalTable: "EvaluationCollaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentCollaborator_EvaluationComponent_EvaluationComponentId",
                        column: x => x.EvaluationComponentId,
                        principalTable: "EvaluationComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationCollaboratorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationLeader_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluationLeader_EvaluationCollaborator_EvaluationCollaboratorId",
                        column: x => x.EvaluationCollaboratorId,
                        principalTable: "EvaluationCollaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentCollaboratorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubcomponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeightRelative = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    PercentMinimun = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    PercentMaximun = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Result = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    ResultCalibrated = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    ResultSimil = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    PointsTotalCalibrated = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaboratorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorDetail_ComponentCollaborator_ComponentCollaboratorId",
                        column: x => x.ComponentCollaboratorId,
                        principalTable: "ComponentCollaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorStage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComponentCollaboratorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaboratorStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorStage_ComponentCollaborator_ComponentCollaboratorId",
                        column: x => x.ComponentCollaboratorId,
                        principalTable: "ComponentCollaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorStage_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaderStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationLeaderId = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderStage_EvaluationLeader_EvaluationLeaderId",
                        column: x => x.EvaluationLeaderId,
                        principalTable: "EvaluationLeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaderStage_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorConduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentCollaboratorDetailId = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaboratorConduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorConduct_ComponentCollaboratorDetail_ComponentCollaboratorDetailId",
                        column: x => x.ComponentCollaboratorDetailId,
                        principalTable: "ComponentCollaboratorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaderCollaborator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderStageId = table.Column<int>(type: "int", nullable: false),
                    EvaluationCollaboratorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderCollaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                        column: x => x.EvaluationCollaboratorId,
                        principalTable: "EvaluationCollaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaderCollaborator_LeaderStage_LeaderStageId",
                        column: x => x.LeaderStageId,
                        principalTable: "LeaderStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_GerencyId",
                table: "Area",
                column: "GerencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_AreaId",
                table: "Charge",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_HierarchyId",
                table: "Charge",
                column: "HierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_ChargeId",
                table: "Collaborator",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaborator_EvaluationCollaboratorId",
                table: "ComponentCollaborator",
                column: "EvaluationCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaborator_EvaluationComponentId",
                table: "ComponentCollaborator",
                column: "EvaluationComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorConduct_ComponentCollaboratorDetailId",
                table: "ComponentCollaboratorConduct",
                column: "ComponentCollaboratorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorDetail_ComponentCollaboratorId",
                table: "ComponentCollaboratorDetail",
                column: "ComponentCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorStage_ComponentCollaboratorId",
                table: "ComponentCollaboratorStage",
                column: "ComponentCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorStage_StageId",
                table: "ComponentCollaboratorStage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentStage_EvaluationComponentId",
                table: "ComponentStage",
                column: "EvaluationComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentStage_StageId",
                table: "ComponentStage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Conduct_LevelId",
                table: "Conduct",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Conduct_SubcomponentId",
                table: "Conduct",
                column: "SubcomponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_PeriodId",
                table: "Evaluation",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_AreaId",
                table: "EvaluationCollaborator",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_ChargeId",
                table: "EvaluationCollaborator",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_CollaboratorId",
                table: "EvaluationCollaborator",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_EvaluationId",
                table: "EvaluationCollaborator",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_GerencyId",
                table: "EvaluationCollaborator",
                column: "GerencyId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_HierarchyId",
                table: "EvaluationCollaborator",
                column: "HierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_LevelId",
                table: "EvaluationCollaborator",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponent_ComponentId",
                table: "EvaluationComponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponent_EvaluationId",
                table: "EvaluationComponent",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLeader_AreaId",
                table: "EvaluationLeader",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLeader_EvaluationCollaboratorId",
                table: "EvaluationLeader",
                column: "EvaluationCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationStage_EvaluationId",
                table: "EvaluationStage",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationStage_StageId",
                table: "EvaluationStage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_LevelId",
                table: "Hierarchy",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HierarchyComponent_ComponentId",
                table: "HierarchyComponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_HierarchyComponent_HierarchyId",
                table: "HierarchyComponent",
                column: "HierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelDetail_LabelId",
                table: "LabelDetail",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderCollaborator_EvaluationCollaboratorId",
                table: "LeaderCollaborator",
                column: "EvaluationCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderCollaborator_LeaderStageId",
                table: "LeaderCollaborator",
                column: "LeaderStageId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderStage_EvaluationLeaderId",
                table: "LeaderStage",
                column: "EvaluationLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderStage_StageId",
                table: "LeaderStage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuDadId",
                table: "Menu",
                column: "MenuDadId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_MenuId",
                table: "RoleMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_RoleId",
                table: "RoleMenu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcomponent_AreaId",
                table: "Subcomponent",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcomponent_ComponentId",
                table: "Subcomponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcomponentValue_ChargeId",
                table: "SubcomponentValue",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcomponentValue_SubcomponentId",
                table: "SubcomponentValue",
                column: "SubcomponentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEndpointLocked_EndpointServiceId",
                table: "UserEndpointLocked",
                column: "EndpointServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEndpointLocked_UserId",
                table: "UserEndpointLocked",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEntity");

            migrationBuilder.DropTable(
                name: "ComponentCollaboratorConduct");

            migrationBuilder.DropTable(
                name: "ComponentCollaboratorStage");

            migrationBuilder.DropTable(
                name: "ComponentStage");

            migrationBuilder.DropTable(
                name: "Conduct");

            migrationBuilder.DropTable(
                name: "EvaluationStage");

            migrationBuilder.DropTable(
                name: "HierarchyComponent");

            migrationBuilder.DropTable(
                name: "LabelDetail");

            migrationBuilder.DropTable(
                name: "LeaderCollaborator");

            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "SubcomponentValue");

            migrationBuilder.DropTable(
                name: "UserEndpointLocked");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "ComponentCollaboratorDetail");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "LeaderStage");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Subcomponent");

            migrationBuilder.DropTable(
                name: "EndpointService");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ComponentCollaborator");

            migrationBuilder.DropTable(
                name: "EvaluationLeader");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "EvaluationComponent");

            migrationBuilder.DropTable(
                name: "EvaluationCollaborator");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Collaborator");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Charge");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Hierarchy");

            migrationBuilder.DropTable(
                name: "Gerency");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
