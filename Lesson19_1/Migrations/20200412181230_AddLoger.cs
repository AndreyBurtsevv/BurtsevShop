using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson19_1.Migrations
{
    public partial class AddLoger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelData_BrandData_BrandDataId",
                table: "ModelData");

            migrationBuilder.AlterColumn<int>(
                name: "BrandDataId",
                table: "ModelData",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "LogData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogData", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ModelData_BrandData_BrandDataId",
                table: "ModelData",
                column: "BrandDataId",
                principalTable: "BrandData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelData_BrandData_BrandDataId",
                table: "ModelData");

            migrationBuilder.DropTable(
                name: "LogData");

            migrationBuilder.AlterColumn<int>(
                name: "BrandDataId",
                table: "ModelData",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelData_BrandData_BrandDataId",
                table: "ModelData",
                column: "BrandDataId",
                principalTable: "BrandData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
