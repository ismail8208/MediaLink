using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLink.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Shares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_InnerUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "InnerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobId",
                table: "Skills",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_JobId",
                table: "Likes",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_JobId",
                table: "Comments",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_UserId",
                table: "Job",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Job_JobId",
                table: "Comments",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Job_JobId",
                table: "Likes",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Job_JobId",
                table: "Skills",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Job_JobId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Job_JobId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Job_JobId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Skills_JobId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Likes_JobId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_JobId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Comments");
        }
    }
}
