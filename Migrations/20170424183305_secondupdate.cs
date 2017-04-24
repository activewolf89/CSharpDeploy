using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bright_Ideas.Migrations
{
    public partial class secondupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Idea = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    LikeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_Like_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true);
        }
    }
}
