using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLink.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addUserNameColumntoinnerUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "InnerUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "InnerUsers");
        }
    }
}
