using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAPI.Migrations
{
    public partial class BookDbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_author_id",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "book_author_id",
                table: "BookAuthors");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Authors",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Authors",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Authors",
                newName: "emailAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Authors",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Authors",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Authors",
                newName: "authorId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "first_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "author_id", "book_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Authors",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Authors",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "Authors",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Authors",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Authors",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "authorId",
                table: "Authors",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Authors",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "book_author_id",
                table: "BookAuthors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                column: "book_author_id");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_author_id",
                table: "BookAuthors",
                column: "author_id");
        }
    }
}
