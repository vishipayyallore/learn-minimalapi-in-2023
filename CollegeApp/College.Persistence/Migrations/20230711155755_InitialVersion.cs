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
                    { new Guid("1bcc881d-e707-4273-9138-e16bb3e493a7"), "A101", 1, "Admin", new DateTime(2023, 7, 11, 21, 27, 55, 74, DateTimeKind.Local).AddTicks(9732), "Description - Minimal API Development", 1, "Admin", new DateTime(2023, 7, 11, 21, 27, 55, 74, DateTimeKind.Local).AddTicks(9742), "Minimal API Development" },
                    { new Guid("c80f1a16-e1f4-40d3-94f1-f93a23cc8091"), "A101", 2, "Admin", new DateTime(2023, 7, 11, 21, 27, 55, 74, DateTimeKind.Local).AddTicks(9747), "Description - Minimal API Development", 4, "Admin", new DateTime(2023, 7, 11, 21, 27, 55, 74, DateTimeKind.Local).AddTicks(9748), "Ultimate API Development" }
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
