using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersManagement.Migrations
{
    /// <inheritdoc />
    public partial class myMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class_Number",
                table: "Pupils");

            migrationBuilder.RenameColumn(
                name: "Learning_Grade",
                table: "Pupils",
                newName: "Old");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Pupils",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Pupils");

            migrationBuilder.RenameColumn(
                name: "Old",
                table: "Pupils",
                newName: "Learning_Grade");

            migrationBuilder.AddColumn<int>(
                name: "Class_Number",
                table: "Pupils",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }
    }
}
