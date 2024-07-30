using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperBestFriends.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_FriendsOfUserId",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_FriendsUserId",
                table: "UserUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersSBF");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "UsersSBF",
                newName: "IX_UsersSBF_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersSBF",
                table: "UsersSBF",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_UsersSBF_FriendsOfUserId",
                table: "UserUser",
                column: "FriendsOfUserId",
                principalTable: "UsersSBF",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_UsersSBF_FriendsUserId",
                table: "UserUser",
                column: "FriendsUserId",
                principalTable: "UsersSBF",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_UsersSBF_FriendsOfUserId",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_UsersSBF_FriendsUserId",
                table: "UserUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersSBF",
                table: "UsersSBF");

            migrationBuilder.RenameTable(
                name: "UsersSBF",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UsersSBF_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_FriendsOfUserId",
                table: "UserUser",
                column: "FriendsOfUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_FriendsUserId",
                table: "UserUser",
                column: "FriendsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
