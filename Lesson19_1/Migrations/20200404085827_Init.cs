using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson19_1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BrandDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelData_BrandData_BrandDataId",
                        column: x => x.BrandDataId,
                        principalTable: "BrandData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BrandData",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "For photos", "Cenon" });

            migrationBuilder.InsertData(
                table: "ModelData",
                columns: new[] { "Id", "BrandDataId", "Name" },
                values: new object[] { 3, 3, "G30" });

            migrationBuilder.CreateIndex(
                name: "IX_ModelData_BrandDataId",
                table: "ModelData",
                column: "BrandDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelData");

            migrationBuilder.DropTable(
                name: "BrandData");
        }
    }
}
