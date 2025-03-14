using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechStore.Migrations
{
    /// <inheritdoc />
    public partial class version_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDBrand",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDBrand",
                table: "Product",
                column: "IDBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_IDBrand",
                table: "Product",
                column: "IDBrand",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_IDBrand",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Product_IDBrand",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IDBrand",
                table: "Product");
        }
    }
}
