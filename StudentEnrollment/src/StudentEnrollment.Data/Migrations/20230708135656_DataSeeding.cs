using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13a5014e-85e0-4f38-ad8f-2a9f25df5b47", null, "Administrator", "ADMINISTRATOR" },
                    { "3a48f41a-21d2-420a-aedf-b42e47a3127b", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Credits", "ModifiedBy", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minimal API Development" },
                    { 2, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultimate API Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13a5014e-85e0-4f38-ad8f-2a9f25df5b47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a48f41a-21d2-420a-aedf-b42e47a3127b");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
