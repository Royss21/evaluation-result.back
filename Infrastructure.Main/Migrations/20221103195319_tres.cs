using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class tres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentCollaboratorStage",
                schema: "EvaResult");

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorComment",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationCollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationComponentStageId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorComment_EvaluationComponentStage_EvaluationComponentStageId",
                        column: x => x.EvaluationComponentStageId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationComponentStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentCollaboratorComment",
                schema: "EvaResult");

            migrationBuilder.CreateTable(
                name: "ComponentCollaboratorStage",
                schema: "EvaResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentCollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationComponentStageId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCollaboratorStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorStage_ComponentCollaborator_ComponentCollaboratorId",
                        column: x => x.ComponentCollaboratorId,
                        principalSchema: "EvaResult",
                        principalTable: "ComponentCollaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentCollaboratorStage_EvaluationComponentStage_EvaluationComponentStageId",
                        column: x => x.EvaluationComponentStageId,
                        principalSchema: "EvaResult",
                        principalTable: "EvaluationComponentStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorStage_ComponentCollaboratorId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage",
                column: "ComponentCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorStage_EvaluationComponentStageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage",
                column: "EvaluationComponentStageId");
        }
    }
}
