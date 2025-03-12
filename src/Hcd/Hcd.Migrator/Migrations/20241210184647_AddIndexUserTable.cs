using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hcd.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE INDEX IX_User_Email ON Users(Email(255));");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX IX_User_Email ON Users;");
        }
    }
}
