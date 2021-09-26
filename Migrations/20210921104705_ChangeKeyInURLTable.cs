using Microsoft.EntityFrameworkCore.Migrations;

namespace URL_Shortener.Migrations
{
    public partial class ChangeKeyInURLTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_URLs",
                table: "URLs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_URLs",
                table: "URLs",
                column: "shortUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_URLs",
                table: "URLs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_URLs",
                table: "URLs",
                column: "sourceUrl");
        }
    }
}
