using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibraryAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorName", "Genre", "Title" },
                values: new object[] { 1, "Martin Scorsese", "Drama", "The Departed" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorName", "Genre", "Title" },
                values: new object[] { 2, "Christopher Nolan", "Drama", "The Dark Knight" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorName", "Genre", "Title" },
                values: new object[] { 3, "Christopher Nolan", "Drama", "Inception" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
