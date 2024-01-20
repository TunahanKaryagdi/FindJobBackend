using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJob.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_image_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Jobs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
