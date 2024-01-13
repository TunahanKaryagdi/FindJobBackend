using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJob.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_experience_to_skill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Skill",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Skill");
        }
    }
}
