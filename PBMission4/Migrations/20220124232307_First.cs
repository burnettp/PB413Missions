using Microsoft.EntityFrameworkCore.Migrations;

namespace PBMission4.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieSubmissions",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<ushort>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSubmissions", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "MovieSubmissions",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Comedy", "Adam McKay", false, null, null, "PG-13", "Anchorman", (ushort)2004 });

            migrationBuilder.InsertData(
                table: "MovieSubmissions",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Comedy", "Edgar Wright", false, null, null, "PG-13", "Scott Pilgrim Vs. The World", (ushort)2010 });

            migrationBuilder.InsertData(
                table: "MovieSubmissions",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Horror/Suspense", "John Carpenter", false, null, null, "PG-13", "The Thing", (ushort)1982 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSubmissions");
        }
    }
}
