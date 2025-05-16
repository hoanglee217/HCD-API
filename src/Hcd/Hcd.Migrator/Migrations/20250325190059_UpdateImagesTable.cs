using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hcd.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Images",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Images",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Format",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Images");
        }
    }
}
