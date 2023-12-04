using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GetAllBooksForSaleWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                schema: "Books",
                table: "books");

            migrationBuilder.DropColumn(
                name: "CourseName",
                schema: "Books",
                table: "books");

            migrationBuilder.DropColumn(
                name: "BookIsbn",
                schema: "Books",
                table: "authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                schema: "Books",
                table: "books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                schema: "Books",
                table: "books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookIsbn",
                schema: "Books",
                table: "authors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
