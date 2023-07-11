using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace College.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CourseType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseId", "CourseType", "CreatedBy", "CreatedDate", "Description", "Duration", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("2f919a8b-ceb6-4123-86cc-6fb18ce10ca1"), null, 2, "Admin", new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7167), null, 4, "Admin", new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7168), "Ultimate API Development" },
                    { new Guid("e0f35ed0-6dcf-42e4-b952-f56c8c883c18"), null, 1, "Admin", new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7144), null, 1, "Admin", new DateTime(2023, 7, 10, 22, 28, 44, 95, DateTimeKind.Local).AddTicks(7158), "Minimal API Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
