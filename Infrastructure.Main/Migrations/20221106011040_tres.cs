using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class tres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderCollaborator_LeaderStage_LeaderStageId",
                schema: "EvaResult",
                table: "LeaderCollaborator");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderStage_EvaluationLeader_EvaluationLeaderId",
                schema: "EvaResult",
                table: "LeaderStage");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderCollaborator_LeaderStage_LeaderStageId",
                schema: "EvaResult",
                table: "LeaderCollaborator",
                column: "LeaderStageId",
                principalSchema: "EvaResult",
                principalTable: "LeaderStage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderStage_EvaluationLeader_EvaluationLeaderId",
                schema: "EvaResult",
                table: "LeaderStage",
                column: "EvaluationLeaderId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationLeader",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderCollaborator_LeaderStage_LeaderStageId",
                schema: "EvaResult",
                table: "LeaderCollaborator");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderStage_EvaluationLeader_EvaluationLeaderId",
                schema: "EvaResult",
                table: "LeaderStage");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderCollaborator_LeaderStage_LeaderStageId",
                schema: "EvaResult",
                table: "LeaderCollaborator",
                column: "LeaderStageId",
                principalSchema: "EvaResult",
                principalTable: "LeaderStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderStage_EvaluationLeader_EvaluationLeaderId",
                schema: "EvaResult",
                table: "LeaderStage",
                column: "EvaluationLeaderId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationLeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
