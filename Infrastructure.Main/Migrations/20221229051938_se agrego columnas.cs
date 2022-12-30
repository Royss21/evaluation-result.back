using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Main.Migrations
{
    public partial class seagregocolumnas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplianceCompetence",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ComplianceCompetenceCalibrated",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotalCalibrated",
                schema: "EvaResult",
                table: "ComponentCollaborator",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplianceCompetence",
                schema: "EvaResult",
                table: "ComponentCollaborator");

            migrationBuilder.DropColumn(
                name: "ComplianceCompetenceCalibrated",
                schema: "EvaResult",
                table: "ComponentCollaborator");

            migrationBuilder.DropColumn(
                name: "SubTotalCalibrated",
                schema: "EvaResult",
                table: "ComponentCollaborator");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "EvaResult",
                table: "ComponentCollaboratorComment",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);
        }
    }
}
