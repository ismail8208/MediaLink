﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLink.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTitleToJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Job");
        }
    }
}
