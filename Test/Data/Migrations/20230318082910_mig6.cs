using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CatalogModel_CatalogId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogModel",
                table: "CatalogModel");

            migrationBuilder.RenameTable(
                name: "CatalogModel",
                newName: "Catalogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catalogs_CatalogId",
                table: "Products",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catalogs_CatalogId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs");

            migrationBuilder.RenameTable(
                name: "Catalogs",
                newName: "CatalogModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogModel",
                table: "CatalogModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CatalogModel_CatalogId",
                table: "Products",
                column: "CatalogId",
                principalTable: "CatalogModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
