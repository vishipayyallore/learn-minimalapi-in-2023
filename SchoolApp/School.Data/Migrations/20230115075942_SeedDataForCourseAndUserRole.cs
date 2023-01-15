using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForCourseAndUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24ff4e9d-4e10-4fdd-ab00-a9461aff7c2e", null, "User", "USER" },
                    { "59ba65f1-c03e-4e9f-8bbe-47a5b88178ab", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Credits", "ModifiedBy", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("d064cc42-442b-433d-9609-b7bcf0a28a82"), "Admin", new DateTime(2023, 1, 15, 7, 59, 42, 465, DateTimeKind.Utc).AddTicks(3143), 5, "Admin", new DateTime(2023, 1, 15, 7, 59, 42, 465, DateTimeKind.Utc).AddTicks(3143), "Ultimate API Development" },
                    { new Guid("e5daea27-ace4-40b0-9802-212f08733704"), "Admin", new DateTime(2023, 1, 15, 7, 59, 42, 465, DateTimeKind.Utc).AddTicks(3136), 3, "Admin", new DateTime(2023, 1, 15, 7, 59, 42, 465, DateTimeKind.Utc).AddTicks(3140), "Minimal API Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24ff4e9d-4e10-4fdd-ab00-a9461aff7c2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59ba65f1-c03e-4e9f-8bbe-47a5b88178ab");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d064cc42-442b-433d-9609-b7bcf0a28a82"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e5daea27-ace4-40b0-9802-212f08733704"));
        }
    }
}
