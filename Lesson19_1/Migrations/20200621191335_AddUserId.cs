using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson19_1.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserDataId",
                table: "OrderData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrderData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDataId",
                table: "BasketData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BasketData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderData_UserDataId",
                table: "OrderData",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketData_UserDataId",
                table: "BasketData",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketData_UserData_UserDataId",
                table: "BasketData",
                column: "UserDataId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderData_UserData_UserDataId",
                table: "OrderData",
                column: "UserDataId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketData_UserData_UserDataId",
                table: "BasketData");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderData_UserData_UserDataId",
                table: "OrderData");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_OrderData_UserDataId",
                table: "OrderData");

            migrationBuilder.DropIndex(
                name: "IX_BasketData_UserDataId",
                table: "BasketData");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "OrderData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderData");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "BasketData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BasketData");
        }
    }
}
