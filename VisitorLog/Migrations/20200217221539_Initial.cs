using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitorLog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDt = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 20, nullable: false),
                    AttendeeName = table.Column<string>(maxLength: 50, nullable: false),
                    AttendeeGroup = table.Column<string>(maxLength: 50, nullable: false),
                    HelperName = table.Column<string>(maxLength: 50, nullable: false),
                    HelperGroup = table.Column<string>(maxLength: 50, nullable: false),
                    Task = table.Column<string>(maxLength: 300, nullable: false),
                    Resolution = table.Column<string>(maxLength: 300, nullable: false),
                    Tags = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visit");
        }
    }
}
