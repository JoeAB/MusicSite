using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicData.Migrations
{
    public partial class Artists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    albumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    dollarPrice = table.Column<decimal>(nullable: false),
                    releaseDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.albumID);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    artistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    startingDate = table.Column<DateTime>(nullable: false),
                    endingDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.artistID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.genreID);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    songID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    songGenregenreID = table.Column<int>(nullable: true),
                    songArtistartistID = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    filePath = table.Column<string>(nullable: true),
                    dollarPrice = table.Column<decimal>(nullable: false),
                    releaseDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.songID);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_songArtistartistID",
                        column: x => x.songArtistartistID,
                        principalTable: "Artists",
                        principalColumn: "artistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_songGenregenreID",
                        column: x => x.songGenregenreID,
                        principalTable: "Genres",
                        principalColumn: "genreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongToAlbumMappings",
                columns: table => new
                {
                    songToAlbumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    songID = table.Column<int>(nullable: true),
                    albumID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongToAlbumMappings", x => x.songToAlbumID);
                    table.ForeignKey(
                        name: "FK_SongToAlbumMappings_Albums_albumID",
                        column: x => x.albumID,
                        principalTable: "Albums",
                        principalColumn: "albumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongToAlbumMappings_Songs_songID",
                        column: x => x.songID,
                        principalTable: "Songs",
                        principalColumn: "songID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "artistID", "description", "endingDate", "name", "startingDate" },
                values: new object[] { 1, "Popular K-pop girl group", null, "TWICE", new DateTime(2015, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_songArtistartistID",
                table: "Songs",
                column: "songArtistartistID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_songGenregenreID",
                table: "Songs",
                column: "songGenregenreID");

            migrationBuilder.CreateIndex(
                name: "IX_SongToAlbumMappings_albumID",
                table: "SongToAlbumMappings",
                column: "albumID");

            migrationBuilder.CreateIndex(
                name: "IX_SongToAlbumMappings_songID",
                table: "SongToAlbumMappings",
                column: "songID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongToAlbumMappings");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
