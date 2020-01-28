using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    Author = table.Column<string>(type: "varchar(40)", nullable: false),
                    Descrtiption = table.Column<string>(type: "varchar(150)", nullable: false),
                    BookType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
