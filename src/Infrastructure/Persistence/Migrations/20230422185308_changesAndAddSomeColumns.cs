using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLink.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changesAndAddSomeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Projects",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Job",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Experiences",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Projects",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Job",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Experiences",
                newName: "Content");
        }
    }
}
