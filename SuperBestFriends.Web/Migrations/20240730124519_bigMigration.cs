using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperBestFriends.Web.Migrations
{
    /// <inheritdoc />
    public partial class bigMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Interests = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FriendsOfUserId = table.Column<long>(type: "bigint", nullable: false),
                    FriendsUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FriendsOfUserId, x.FriendsUserId });
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FriendsOfUserId",
                        column: x => x.FriendsOfUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FriendsUserId",
                        column: x => x.FriendsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BirthDate", "Email", "FirstName", "Interests", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, "", new DateTime(1998, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "jean.michel@gmail.com", "Jean", "Blah,blah,blah", "Michel", "0638451475" },
                    { 2L, "", new DateTime(1985, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "marie.dupont@yahoo.fr", "Marie", "Yoga,Cuisine,Lecture", "Dupont", "0645789632" },
                    { 3L, "", new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "p.durand@hotmail.com", "Pierre", "Football,Cinéma,Voyages", "Durand", "0712345678" },
                    { 4L, "", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophie.martin@gmail.com", "Sophie", "Photographie,Danse,Jardinage", "Martin", "0698765432" },
                    { 5L, "", new DateTime(1988, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "thomas.leroy@outlook.com", "Thomas", "Musique,Technologie,Randonnée", "Leroy", "0623456789" },
                    { 6L, "", new DateTime(1995, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "camille.dubois@free.fr", "Camille", "Peinture,Théâtre,Natation", "Dubois", "0787654321" },
                    { 7L, "", new DateTime(1987, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas.moreau@orange.fr", "Lucas", "Jeux vidéo,Ski,Cuisine asiatique", "Moreau", "0634567890" },
                    { 8L, "", new DateTime(1993, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.lefebvre@gmail.com", "Emma", "Mode,Fitness,Voyages", "Lefebvre", "0756789012" },
                    { 9L, "", new DateTime(1991, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nicolas.roux@yahoo.com", "Nicolas", "Escalade,Photographie,Histoire", "Roux", "0678901234" },
                    { 10L, "", new DateTime(1989, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "chloe.girard@hotmail.fr", "Chloé", "Yoga,Méditation,Cuisine végétarienne", "Girard", "0701234567" },
                    { 11L, "", new DateTime(1994, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "antoine.blanc@gmail.com", "Antoine", "Basket,Littérature,Astronomie", "Blanc", "0654321098" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FriendsUserId",
                table: "UserUser",
                column: "FriendsUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
