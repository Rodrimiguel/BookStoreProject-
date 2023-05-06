using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOOKSTORE00.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyAutorOnBookModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Book",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Book");
        }
    }
}
