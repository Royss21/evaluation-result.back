using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class asdsad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaborator_EvaluationComponent_EvaluationComponentId",
                schema: "EvaResult",
                table: "ComponentCollaborator");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaborator_EvaluationComponent_EvaluationComponentId",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                column: "EvaluationComponentId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationComponent",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentCollaborator_EvaluationComponent_EvaluationComponentId",
                schema: "EvaResult",
                table: "ComponentCollaborator");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentCollaborator_EvaluationComponent_EvaluationComponentId",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                column: "EvaluationComponentId",
                principalSchema: "EvaResult",
                principalTable: "EvaluationComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
