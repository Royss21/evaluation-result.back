using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class cuatro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaborator");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaboratorComment_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaboratorConduct_ComponentCollaboratorDetail_ComponentCollaboratorDetailId",
                schema: "EvaResult",
                table: "ComponentCollaboratorConduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaboratorDetail_ComponentCollaborator_ComponentCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationLeader_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "LeaderCollaborator");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "EvaResult",
                table: "Evaluation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RangeParameter",
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
                    table.PrimaryKey("PK_RangeParameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterValue",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    NameProperty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RangeParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_ParameterValue_RangeParameter_RangeParameterId",
                        column: x => x.RangeParameterId,
                        principalSchema: "Config",
                        principalTable: "RangeParameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValue_RangeParameterId",
                schema: "Config",
                table: "ParameterValue",
                column: "RangeParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaboratorComment_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaboratorConduct_ComponentCollaboratorDetail_ComponentCollaboratorDetailId",
                schema: "EvaResult",
                table: "ComponentCollaboratorConduct",
                column: "ComponentCollaboratorDetailId",
                principalSchema: "EvaResult",
                principalTable: "ComponentCollaboratorDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaboratorDetail_ComponentCollaborator_ComponentCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorDetail",
                column: "ComponentCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "ComponentCollaborator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationLeader_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "LeaderCollaborator",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaborator");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaboratorComment_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaboratorConduct_ComponentCollaboratorDetail_ComponentCollaboratorDetailId",
                schema: "EvaResult",
                table: "ComponentCollaboratorConduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaboratorDetail_ComponentCollaborator_ComponentCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationLeader_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "LeaderCollaborator");

            migrationBuilder.DropTable(
                name: "ParameterValue",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "RangeParameter",
                schema: "Config");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "EvaResult",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaboratorComment_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaboratorConduct_ComponentCollaboratorDetail_ComponentCollaboratorDetailId",
                schema: "EvaResult",
                table: "ComponentCollaboratorConduct",
                column: "ComponentCollaboratorDetailId",
                principalSchema: "EvaResult",
                principalTable: "ComponentCollaboratorDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaboratorDetail_ComponentCollaborator_ComponentCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorDetail",
                column: "ComponentCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "ComponentCollaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationLeader_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderCollaborator_EvaluationCollaborator_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "LeaderCollaborator",
                column: "EvaluationCollaboratorId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationCollaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
