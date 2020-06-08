using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneStore.Infra.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Description = table.Column<string>(type: "varchar(300)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15, 2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(15, 2)", nullable: true, defaultValue: 0m),
                    Width = table.Column<decimal>(type: "decimal(15, 2)", nullable: true, defaultValue: 0m),
                    Depth = table.Column<decimal>(type: "decimal(15, 2)", nullable: true, defaultValue: 0m),
                    Type = table.Column<string>(nullable: false),
                    Compatibility = table.Column<string>(nullable: true),
                    Capacity = table.Column<double>(nullable: true),
                    Color = table.Column<int>(nullable: true),
                    Display = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
