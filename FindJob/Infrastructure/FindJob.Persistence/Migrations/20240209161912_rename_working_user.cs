using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJob.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rename_working_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingUsers_AspNetUsers_UserId",
                table: "WorkingUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingUsers_Companies_CompanyId",
                table: "WorkingUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingUsers",
                table: "WorkingUsers");

            migrationBuilder.RenameTable(
                name: "WorkingUsers",
                newName: "CompanyStaffs");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingUsers_UserId",
                table: "CompanyStaffs",
                newName: "IX_CompanyStaffs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingUsers_CompanyId",
                table: "CompanyStaffs",
                newName: "IX_CompanyStaffs_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyStaffs",
                table: "CompanyStaffs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStaffs_AspNetUsers_UserId",
                table: "CompanyStaffs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStaffs_Companies_CompanyId",
                table: "CompanyStaffs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStaffs_AspNetUsers_UserId",
                table: "CompanyStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStaffs_Companies_CompanyId",
                table: "CompanyStaffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyStaffs",
                table: "CompanyStaffs");

            migrationBuilder.RenameTable(
                name: "CompanyStaffs",
                newName: "WorkingUsers");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyStaffs_UserId",
                table: "WorkingUsers",
                newName: "IX_WorkingUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyStaffs_CompanyId",
                table: "WorkingUsers",
                newName: "IX_WorkingUsers_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingUsers",
                table: "WorkingUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingUsers_AspNetUsers_UserId",
                table: "WorkingUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingUsers_Companies_CompanyId",
                table: "WorkingUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
