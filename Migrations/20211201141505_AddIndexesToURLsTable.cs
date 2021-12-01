using Microsoft.EntityFrameworkCore.Migrations;

namespace URL_Shortener.Migrations
{
    public partial class AddIndexesToURLsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_URLs_SourceUrl_ShortUrl",
                table: "URLs",
                columns: new[] { "SourceUrl", "ShortUrl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_URLs_SourceUrl_ShortUrl",
                table: "URLs");
        }
    }
}
