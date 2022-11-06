using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EvaluationLeader_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLeader_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationCollaboratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EvaluationLeader_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLeader_EvaluationCollaboratorId",
                schema: "EvaResult",
                table: "EvaluationLeader",
                column: "EvaluationCollaboratorId",
                unique: true);
        }
    }
}
