using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace exclucv.DAL.Migrations
{
    public partial class ExperienceSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceSkill");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "WorkExperience",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "WorkExperience");

            migrationBuilder.CreateTable(
                name: "ExperienceSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(nullable: true),
                    WorkExperienceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceSkill_WorkExperience_WorkExperienceId",
                        column: x => x.WorkExperienceId,
                        principalTable: "WorkExperience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceSkill_WorkExperienceId",
                table: "ExperienceSkill",
                column: "WorkExperienceId");
        }
    }
}
