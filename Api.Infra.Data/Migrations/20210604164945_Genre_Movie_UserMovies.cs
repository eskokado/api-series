using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Genre_Movie_UserMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("31f4d637-8d17-43d2-9e94-603a04ac7f21"));

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GenreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMovies",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovies", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_UserMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("c0ba3061-8e51-4398-a7e3-a58d67630662"), new DateTime(2021, 6, 4, 13, 49, 44, 548, DateTimeKind.Local).AddTicks(1599), "esk@email.com", "Edson Shideki Kokado", new DateTime(2021, 6, 4, 13, 49, 44, 551, DateTimeKind.Local).AddTicks(6399) });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Name",
                table: "Movies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MovieId",
                table: "UserMovies",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0ba3061-8e51-4398-a7e3-a58d67630662"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("31f4d637-8d17-43d2-9e94-603a04ac7f21"), new DateTime(2021, 6, 1, 9, 56, 23, 968, DateTimeKind.Local).AddTicks(3307), "esk@email.com", "Edson Shideki Kokado", new DateTime(2021, 6, 1, 9, 56, 23, 970, DateTimeKind.Local).AddTicks(5411) });
        }
    }
}
