﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersManagement.Migrations
{
    /// <inheritdoc />
    public partial class educatorWatchFeatureAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducatorId",
                table: "Pupils",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_EducatorId",
                table: "Pupils",
                column: "EducatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_Teachers_EducatorId",
                table: "Pupils",
                column: "EducatorId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_Teachers_EducatorId",
                table: "Pupils");

            migrationBuilder.DropIndex(
                name: "IX_Pupils_EducatorId",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "EducatorId",
                table: "Pupils");
        }
    }
}
