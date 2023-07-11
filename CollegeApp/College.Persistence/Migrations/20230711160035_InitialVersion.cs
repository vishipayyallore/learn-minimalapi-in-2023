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
                    { new Guid("5e181656-2233-46f6-ab5e-ac5229e6244d"), "A102", 2, "Admin", new DateTime(2023, 7, 11, 21, 30, 35, 835, DateTimeKind.Local).AddTicks(4555), "Description - Ultimate API Development", 4, "Admin", new DateTime(2023, 7, 11, 21, 30, 35, 835, DateTimeKind.Local).AddTicks(4556), "Ultimate API Development" },
                    { new Guid("d4bc7d3f-261c-4cec-ad8b-cabf4cb3174d"), "A101", 1, "Admin", new DateTime(2023, 7, 11, 21, 30, 35, 835, DateTimeKind.Local).AddTicks(4523), "Description - Minimal API Development", 1, "Admin", new DateTime(2023, 7, 11, 21, 30, 35, 835, DateTimeKind.Local).AddTicks(4547), "Minimal API Development" }
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
