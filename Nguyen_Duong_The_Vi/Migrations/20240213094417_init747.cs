using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nguyen_Duong_The_Vi.Migrations
{
    public partial class init747 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostTempID",
                table: "postCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "postTemps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIEW = table.Column<int>(type: "int", nullable: true),
                    IDTAUTHOR = table.Column<int>(type: "int", nullable: true),
                    LIKE = table.Column<int>(type: "int", nullable: true),
                    AUTHOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUMMARY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PUBLISHED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONTEXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TEMP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postTemps", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_postCategories_PostTempID",
                table: "postCategories",
                column: "PostTempID");

            migrationBuilder.AddForeignKey(
                name: "FK_postCategories_postTemps_PostTempID",
                table: "postCategories",
                column: "PostTempID",
                principalTable: "postTemps",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postCategories_postTemps_PostTempID",
                table: "postCategories");

            migrationBuilder.DropTable(
                name: "postTemps");

            migrationBuilder.DropIndex(
                name: "IX_postCategories_PostTempID",
                table: "postCategories");

            migrationBuilder.DropColumn(
                name: "PostTempID",
                table: "postCategories");
        }
    }
}
