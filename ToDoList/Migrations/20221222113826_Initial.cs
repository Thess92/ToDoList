using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "First Project" },
                    { 2, "Second Project" },
                    { 3, "Third Project" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DueDate", "IsDone", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "First Task" },
                    { 2, new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "Second Task" },
                    { 3, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "Third Task" },
                    { 4, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "Forth Task" },
                    { 5, new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, "Fifth Task" },
                    { 6, new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, "Sixth Task" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
