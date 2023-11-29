using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFC_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "authors",
                schema: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                schema: "Books",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "text", nullable: false),
                    BookTitle = table.Column<string>(type: "text", nullable: false),
                    Edition = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Isbn);
                });

            migrationBuilder.CreateTable(
                name: "conditions",
                schema: "Books",
                columns: table => new
                {
                    condition = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conditions", x => x.condition);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                schema: "Books",
                columns: table => new
                {
                    CourseName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseName);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                schema: "Books",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "integer", nullable: false),
                    booksIsbn = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.booksIsbn });
                    table.ForeignKey(
                        name: "FK_AuthorBook_authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalSchema: "Books",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_books_booksIsbn",
                        column: x => x.booksIsbn,
                        principalSchema: "Books",
                        principalTable: "books",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booksForSale",
                schema: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    condition = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    BookIsbn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booksForSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_booksForSale_books_BookIsbn",
                        column: x => x.BookIsbn,
                        principalSchema: "Books",
                        principalTable: "books",
                        principalColumn: "Isbn");
                    table.ForeignKey(
                        name: "FK_booksForSale_conditions_condition",
                        column: x => x.condition,
                        principalSchema: "Books",
                        principalTable: "conditions",
                        principalColumn: "condition",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCourse",
                schema: "Books",
                columns: table => new
                {
                    BooksIsbn = table.Column<string>(type: "text", nullable: false),
                    coursesCourseName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCourse", x => new { x.BooksIsbn, x.coursesCourseName });
                    table.ForeignKey(
                        name: "FK_BookCourse_books_BooksIsbn",
                        column: x => x.BooksIsbn,
                        principalSchema: "Books",
                        principalTable: "books",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCourse_courses_coursesCourseName",
                        column: x => x.coursesCourseName,
                        principalSchema: "Books",
                        principalTable: "courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_booksIsbn",
                schema: "Books",
                table: "AuthorBook",
                column: "booksIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_BookCourse_coursesCourseName",
                schema: "Books",
                table: "BookCourse",
                column: "coursesCourseName");

            migrationBuilder.CreateIndex(
                name: "IX_booksForSale_BookIsbn",
                schema: "Books",
                table: "booksForSale",
                column: "BookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_booksForSale_condition",
                schema: "Books",
                table: "booksForSale",
                column: "condition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "BookCourse",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "booksForSale",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "authors",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "courses",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "books",
                schema: "Books");

            migrationBuilder.DropTable(
                name: "conditions",
                schema: "Books");
        }
    }
}
