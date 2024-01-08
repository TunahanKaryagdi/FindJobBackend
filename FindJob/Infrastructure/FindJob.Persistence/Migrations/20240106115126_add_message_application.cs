using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJob.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_message_application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Applications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Applications");
        }
    }
}
