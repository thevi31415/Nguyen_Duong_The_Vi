using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nguyen_Duong_The_Vi.Migrations
{
    public partial class init3454 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDBAIVIET = table.Column<int>(type: "int", nullable: true),
                    IDUSER = table.Column<int>(type: "int", nullable: true),
                    LIKE = table.Column<int>(type: "int", nullable: true),
                    TENUSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NGAYBINHLUAN = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");
        }
    }
}
