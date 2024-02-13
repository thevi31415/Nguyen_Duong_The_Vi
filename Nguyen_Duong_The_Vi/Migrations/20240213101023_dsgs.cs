using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nguyen_Duong_The_Vi.Migrations
{
    public partial class dsgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "postCategoryTemps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPOSTTEMP = table.Column<int>(type: "int", nullable: false),
                    IDCATEGORY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postCategoryTemps", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postCategoryTemps");
        }
    }
}
