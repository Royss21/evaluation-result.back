using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class firts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Employee");

            migrationBuilder.EnsureSchema(
                name: "Config");

            migrationBuilder.EnsureSchema(
                name: "EvaResult");

            migrationBuilder.CreateTable(
                name: "AuditEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    NewValues = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Entity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Method = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PathEndpoint = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formula",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FormulaReal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FormulaQuery = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gerency",
                schema: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "ParameterRange",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsInternalConfiguration = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                schema: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GerencyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Gerency_GerencyId",
                        column: x => x.GerencyId,
                        principalSchema: "Employee",
                        principalTable: "Gerency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabelDetail",
                schema: "Config",
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelDetail_Label_LabelId",
                        column: x => x.LabelId,
                        principalSchema: "Config",
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hierarchy",
                schema: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchy_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "Config",
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParameterValue",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    NameProperty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EntityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterValue_ParameterRange_ParameterRangeId",
                        column: x => x.ParameterRangeId,
                        principalSchema: "Config",
                        principalTable: "ParameterRange",
                        principalColumn: "Id");
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "Evaluation",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalSchema: "EvaResult",
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluation_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Config",
                        principalTable: "Status",
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcomponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcomponent_Area_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "Employee",
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subcomponent_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "Config",
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subcomponent_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalSchema: "Config",
                        principalTable: "Formula",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                schema: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    HierarchyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_Area_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "Employee",
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Charge_Hierarchy_HierarchyId",
                        column: x => x.HierarchyId,
                        principalSchema: "Employee",
                        principalTable: "Hierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HierarchyComponent",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HierarchyId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchyComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HierarchyComponent_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "Config",
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HierarchyComponent_Hierarchy_HierarchyId",
                        column: x => x.HierarchyId,
                        principalSchema: "Employee",
                        principalTable: "Hierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationComponent",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationComponent_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "Config",
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationComponent_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "EvaResult",
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationComponent_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Config",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conduct",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    SubcomponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conduct_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "Config",
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conduct_Subcomponent_SubcomponentId",
                        column: x => x.SubcomponentId,
                        principalSchema: "Config",
                        principalTable: "Subcomponent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collaborator",
                schema: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChargeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateBirthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEgress = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborator_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalSchema: "Employee",
                        principalTable: "Charge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubcomponentValue",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcomponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChargeId = table.Column<int>(type: "int", nullable: true),
                    RelativeWeight = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MinimunPercentage = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MaximunPercentage = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcomponentValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubcomponentValue_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalSchema: "Employee",
                        principalTable: "Charge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubcomponentValue_Subcomponent_SubcomponentId",
                        column: x => x.SubcomponentId,
                        principalSchema: "Config",
                        principalTable: "Subcomponent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationComponentStage",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationComponentId = table.Column<int>(type: "int", nullable: true),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationComponentStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationComponentStage_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "EvaResult",
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationComponentStage_EvaluationComponent_EvaluationComponentId",
                        column: x => x.EvaluationComponentId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationComponent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluationComponentStage_Stage_StageId",
                        column: x => x.StageId,
                        principalSchema: "Config",
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCollaborator",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GerencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HierarchyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCollaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalSchema: "Employee",
                        principalTable: "Collaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCollaborator_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "EvaResult",
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaborator",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationComponentId = table.Column<int>(type: "int", nullable: false),
                    EvaluationCollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HierarchyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeightHierarchy = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    ExcessSubtotal = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Total = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    TotalCalibrated = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Excess = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                        column: x => x.EvaluationCollaboratorId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationCollaborator",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComponentCollaborator_EvaluationComponent_EvaluationComponentId",
                        column: x => x.EvaluationComponentId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentCollaborator_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Config",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorComment",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationCollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationComponentStageId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaboratorComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorComment_EvaluationCollaborator_EvaluationCollaboratorId",
                        column: x => x.EvaluationCollaboratorId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationCollaborator",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorComment_EvaluationComponentStage_EvaluationComponentStageId",
                        column: x => x.EvaluationComponentStageId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationComponentStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorComment_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Config",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationLeader",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationCollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationComponentId = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationLeader_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "EvaResult",
                        principalTable: "Evaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationLeader_EvaluationCollaborator_EvaluationCollaboratorId",
                        column: x => x.EvaluationCollaboratorId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationCollaborator",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluationLeader_EvaluationComponent_EvaluationComponentId",
                        column: x => x.EvaluationComponentId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorDetail",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentCollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcomponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeightRelative = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MinimunPercentage = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    MaximunPercentage = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Result = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Compliance = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Points = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    PointsCalibrated = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    FormulaName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FormulaQuery = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaboratorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorDetail_ComponentCollaborator_ComponentCollaboratorId",
                        column: x => x.ComponentCollaboratorId,
                        principalSchema: "EvaResult",
                        principalTable: "ComponentCollaborator",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaderStage",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationLeaderId = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderStage_EvaluationLeader_EvaluationLeaderId",
                        column: x => x.EvaluationLeaderId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationLeader",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaderStage_Stage_StageId",
                        column: x => x.StageId,
                        principalSchema: "Config",
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorConduct",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentCollaboratorDetailId = table.Column<int>(type: "int", nullable: false),
                    ConductDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConductPoints = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    ConductPointsCalibrated = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaboratorConduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorConduct_ComponentCollaboratorDetail_ComponentCollaboratorDetailId",
                        column: x => x.ComponentCollaboratorDetailId,
                        principalSchema: "EvaResult",
                        principalTable: "ComponentCollaboratorDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaderCollaborator",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderStageId = table.Column<int>(type: "int", nullable: false),
                    EvaluationCollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderCollaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                        column: x => x.EvaluationCollaboratorId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationCollaborator",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaderCollaborator_LeaderStage_LeaderStageId",
                        column: x => x.LeaderStageId,
                        principalSchema: "EvaResult",
                        principalTable: "LeaderStage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_GerencyId",
                schema: "Employee",
                table: "Area",
                column: "GerencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_AreaId",
                schema: "Employee",
                table: "Charge",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_HierarchyId",
                schema: "Employee",
                table: "Charge",
                column: "HierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_ChargeId",
                schema: "Employee",
                table: "Collaborator",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                column: "EvaluationCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaborator_EvaluationComponentId",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                column: "EvaluationComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaborator_StatusId",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorComment_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                column: "EvaluationCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorComment_EvaluationComponentStageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                column: "EvaluationComponentStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorComment_StatusId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorConduct_ComponentCollaboratorDetailId",
                schema: "EvaResult",
                table: "ComponentCollaboratorConduct",
                column: "ComponentCollaboratorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorDetail_ComponentCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorDetail",
                column: "ComponentCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Conduct_LevelId",
                schema: "Config",
                table: "Conduct",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Conduct_SubcomponentId",
                schema: "Config",
                table: "Conduct",
                column: "SubcomponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_PeriodId",
                schema: "EvaResult",
                table: "Evaluation",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_StatusId",
                schema: "EvaResult",
                table: "Evaluation",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_CollaboratorId",
                schema: "EvaResult",
                table: "EvaluationCollaborator",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCollaborator_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationCollaborator",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponent_ComponentId",
                schema: "EvaResult",
                table: "EvaluationComponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponent_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponent",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponent_StatusId",
                schema: "EvaResult",
                table: "EvaluationComponent",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponentStage_EvaluationComponentId",
                schema: "EvaResult",
                table: "EvaluationComponentStage",
                column: "EvaluationComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponentStage_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponentStage",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationComponentStage_StageId",
                schema: "EvaResult",
                table: "EvaluationComponentStage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLeader_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLeader_EvaluationComponentId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLeader_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_LevelId",
                schema: "Employee",
                table: "Hierarchy",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HierarchyComponent_ComponentId",
                schema: "Config",
                table: "HierarchyComponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_HierarchyComponent_HierarchyId",
                schema: "Config",
                table: "HierarchyComponent",
                column: "HierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelDetail_LabelId",
                schema: "Config",
                table: "LabelDetail",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "LeaderCollaborator",
                column: "EvaluationCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderCollaborator_LeaderStageId",
                schema: "EvaResult",
                table: "LeaderCollaborator",
                column: "LeaderStageId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderStage_EvaluationLeaderId",
                schema: "EvaResult",
                table: "LeaderStage",
                column: "EvaluationLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderStage_StageId",
                schema: "EvaResult",
                table: "LeaderStage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuDadId",
                table: "Menu",
                column: "MenuDadId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValue_ParameterRangeId",
                schema: "Config",
                table: "ParameterValue",
                column: "ParameterRangeId");

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
                schema: "Config",
                table: "Subcomponent",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcomponent_ComponentId",
                schema: "Config",
                table: "Subcomponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcomponent_FormulaId",
                schema: "Config",
                table: "Subcomponent",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcomponentValue_ChargeId",
                schema: "Config",
                table: "SubcomponentValue",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcomponentValue_SubcomponentId",
                schema: "Config",
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
                name: "ComponentCollaboratorComment",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "ComponentCollaboratorConduct",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "Conduct",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "HierarchyComponent",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "LabelDetail",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "LeaderCollaborator",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "ParameterValue",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "SubcomponentValue",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "UserEndpointLocked");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "EvaluationComponentStage",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "ComponentCollaboratorDetail",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "Label",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "LeaderStage",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "ParameterRange",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Subcomponent",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "EndpointService");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ComponentCollaborator",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "EvaluationLeader",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "Stage",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "Formula",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "EvaluationCollaborator",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "EvaluationComponent",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "Collaborator",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Component",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "Evaluation",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "Charge",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Period",
                schema: "EvaResult");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "Area",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Hierarchy",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Gerency",
                schema: "Employee");

            migrationBuilder.DropTable(
                name: "Level",
                schema: "Config");
        }
    }
}
