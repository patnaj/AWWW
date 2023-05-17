using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ocenyvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "Marks",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Marks");
        }
    }
}
