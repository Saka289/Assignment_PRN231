using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAPI.Migrations
{
    public partial class updateBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_book_id",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_author_id",
                table: "BookAuthors");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_author_id",
                table: "BookAuthors",
                column: "author_id",
                principalTable: "Authors",
                principalColumn: "author_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_book_id",
                table: "BookAuthors",
                column: "book_id",
                principalTable: "Books",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_author_id",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_book_id",
                table: "BookAuthors");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_book_id",
                table: "BookAuthors",
                column: "book_id",
                principalTable: "Authors",
                principalColumn: "author_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_author_id",
                table: "BookAuthors",
                column: "author_id",
                principalTable: "Books",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
