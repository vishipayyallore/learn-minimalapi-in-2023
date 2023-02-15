using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeOffsetAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac7fa566-e2f1-4487-8f72-d4e1792e3680");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7de4a4-32ba-4be5-8186-268feb7211e4");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("0d04b78d-eacb-4b82-93cf-7caccb253a46"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("ee759492-0ab7-4b77-87e6-00a71db963a1"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Students",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateofBirth",
                table: "Students",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Students",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Enrollments",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Enrollments",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Courses",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Courses",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5490680e-a4c2-4786-80e3-18a478efe668", null, "User", "USER" },
                    { "70044aa5-907f-434c-ac5e-99956d745683", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Credits", "ModifiedBy", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("92af533e-7682-4a1b-9757-1dbcbe1f8bf8"), "Admin", new DateTimeOffset(new DateTime(2023, 2, 14, 10, 21, 19, 681, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 0, 0, 0, 0)), 3, "Admin", new DateTimeOffset(new DateTime(2023, 2, 14, 10, 21, 19, 681, DateTimeKind.Unspecified).AddTicks(6506), new TimeSpan(0, 0, 0, 0, 0)), "Minimal API Development" },
                    { new Guid("e88a7a5c-0129-459a-a884-29145dd46a56"), "Admin", new DateTimeOffset(new DateTime(2023, 2, 14, 10, 21, 19, 681, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 0, 0, 0, 0)), 5, "Admin", new DateTimeOffset(new DateTime(2023, 2, 14, 10, 21, 19, 681, DateTimeKind.Unspecified).AddTicks(6510), new TimeSpan(0, 0, 0, 0, 0)), "Ultimate API Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5490680e-a4c2-4786-80e3-18a478efe668");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70044aa5-907f-434c-ac5e-99956d745683");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("92af533e-7682-4a1b-9757-1dbcbe1f8bf8"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e88a7a5c-0129-459a-a884-29145dd46a56"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateofBirth",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ac7fa566-e2f1-4487-8f72-d4e1792e3680", null, "Administrator", "ADMINISTRATOR" },
                    { "fc7de4a4-32ba-4be5-8186-268feb7211e4", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Credits", "ModifiedBy", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0d04b78d-eacb-4b82-93cf-7caccb253a46"), "Admin", new DateTime(2023, 1, 18, 13, 32, 48, 470, DateTimeKind.Utc).AddTicks(418), 5, "Admin", new DateTime(2023, 1, 18, 13, 32, 48, 470, DateTimeKind.Utc).AddTicks(419), "Ultimate API Development" },
                    { new Guid("ee759492-0ab7-4b77-87e6-00a71db963a1"), "Admin", new DateTime(2023, 1, 18, 13, 32, 48, 470, DateTimeKind.Utc).AddTicks(388), 3, "Admin", new DateTime(2023, 1, 18, 13, 32, 48, 470, DateTimeKind.Utc).AddTicks(394), "Minimal API Development" }
                });
        }
    }
}
