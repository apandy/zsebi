using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Zsebi2.Migrations
{
    public partial class DbUpdate001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Excerpt = table.Column<string>(type: "longtext", nullable: true),
                    HtmlBody = table.Column<string>(type: "longtext", nullable: true),
                    MoreInfoUrl = table.Column<string>(type: "longtext", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ThumbnailfileName = table.Column<string>(type: "longtext", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    callsign = table.Column<string>(type: "longtext", nullable: true),
                    email = table.Column<string>(type: "longtext", nullable: true),
                    image = table.Column<string>(type: "longtext", nullable: true),
                    name = table.Column<string>(type: "longtext", nullable: true),
                    post = table.Column<string>(type: "longtext", nullable: true),
                    status = table.Column<string>(type: "longtext", nullable: true),
                    subsystem = table.Column<string>(type: "longtext", nullable: true),
                    system = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
