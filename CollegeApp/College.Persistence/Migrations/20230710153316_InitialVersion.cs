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
                    { new Guid("8b2c08e2-a9d7-4a70-961d-4860cb843c43"), null, 2, "Admin", new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(5018), null, 4, "Admin", new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(5019), "Ultimate API Development" },
                    { new Guid("d022754a-4bca-476f-a3f5-4875d25bd2cd"), null, 1, "Admin", new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(4996), null, 1, "Admin", new DateTime(2023, 7, 10, 21, 3, 16, 787, DateTimeKind.Local).AddTicks(5010), "Minimal API Development" }
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
