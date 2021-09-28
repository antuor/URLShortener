using Microsoft.EntityFrameworkCore.Migrations;

namespace URL_Shortener.Migrations
{
    public partial class ChangeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sourceUrl",
                table: "URLs",
                newName: "SourceUrl");

            migrationBuilder.RenameColumn(
                name: "shortUrl",
                table: "URLs",
                newName: "ShortUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceUrl",
                table: "URLs",
                newName: "sourceUrl");

            migrationBuilder.RenameColumn(
                name: "ShortUrl",
                table: "URLs",
                newName: "shortUrl");
        }
    }
}
