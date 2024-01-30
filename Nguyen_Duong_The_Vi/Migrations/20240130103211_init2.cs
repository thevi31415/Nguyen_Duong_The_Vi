using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nguyen_Duong_The_Vi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    IDCATEGORY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTEXT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.IDCATEGORY);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIEW = table.Column<int>(type: "int", nullable: true),
                    LIKE = table.Column<int>(type: "int", nullable: true),
                    AUTHOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUMMARY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PUBLISHED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONTEXT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "postCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPOST = table.Column<int>(type: "int", nullable: false),
                    IDCATEGORY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_postCategories_categories_IDCATEGORY",
                        column: x => x.IDCATEGORY,
                        principalTable: "categories",
                        principalColumn: "IDCATEGORY",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postCategories_posts_IDPOST",
                        column: x => x.IDPOST,
                        principalTable: "posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_postCategories_IDCATEGORY",
                table: "postCategories",
                column: "IDCATEGORY");

            migrationBuilder.CreateIndex(
                name: "IX_postCategories_IDPOST",
                table: "postCategories",
                column: "IDPOST");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postCategories");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
