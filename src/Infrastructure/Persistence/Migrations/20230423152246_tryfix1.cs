using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLink.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tryfix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Job_JobId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_InnerUsers_UserId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Job_JobId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Job_JobId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameIndex(
                name: "IX_Job_UserId",
                table: "Jobs",
                newName: "IX_Jobs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Jobs_JobId",
                table: "Comments",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_InnerUsers_UserId",
                table: "Jobs",
                column: "UserId",
                principalTable: "InnerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Jobs_JobId",
                table: "Likes",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Jobs_JobId",
                table: "Skills",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Jobs_JobId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_InnerUsers_UserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Jobs_JobId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Jobs_JobId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_UserId",
                table: "Job",
                newName: "IX_Job_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Job_JobId",
                table: "Comments",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_InnerUsers_UserId",
                table: "Job",
                column: "UserId",
                principalTable: "InnerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Job_JobId",
                table: "Likes",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Job_JobId",
                table: "Skills",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");
        }
    }
}
