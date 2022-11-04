using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaboratorStage_Stage_StageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage");

            migrationBuilder.DropIndex(
                name: "IX_ComponentCollaboratorStage_StageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage");

            migrationBuilder.DropColumn(
                name: "StageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCollaboratorStage_StageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaboratorStage_Stage_StageId",
                schema: "EvaResult",
                table: "ComponentCollaboratorStage",
                column: "StageId",
                principalSchema: "Config",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
