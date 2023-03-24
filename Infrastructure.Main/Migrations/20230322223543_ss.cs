using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationCollaborator_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationCollaborator");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationComponent_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationComponentStage_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponentStage");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationLeader_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationLeader");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationCollaborator_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationCollaborator",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationComponent_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponent",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationComponentStage_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponentStage",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationLeader_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationCollaborator_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationCollaborator");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationComponent_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationComponentStage_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponentStage");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationLeader_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationLeader");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationCollaborator_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationCollaborator",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationComponent_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponent",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationComponentStage_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationComponentStage",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationLeader_Evaluation_EvaluationId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationId",
                principalSchema: "EvaResult",
                principalTable: "Evaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
