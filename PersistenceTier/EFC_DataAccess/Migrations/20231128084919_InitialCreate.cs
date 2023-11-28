using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFC_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorDto",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Isbn = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    BookTitle = table.Column<string>(type: "text", nullable: false),
                    Edition = table.Column<string>(type: "text", nullable: false),
                    PageCount = table.Column<int>(type: "integer", nullable: true),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => new { x.Isbn, x.Owner });
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    BookIsbn = table.Column<int>(type: "integer", nullable: true),
                    BookOwner = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Name);
                    table.ForeignKey(
                        name: "FK_authors_books_BookIsbn_BookOwner",
                        columns: x => new { x.BookIsbn, x.BookOwner },
                        principalTable: "books",
                        principalColumns: new[] { "Isbn", "Owner" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_authors_BookIsbn_BookOwner",
                table: "authors",
                columns: new[] { "BookIsbn", "BookOwner" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorDto");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
