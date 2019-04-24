using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class Prayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "484cc765-a4e2-4f2a-8f58-570754303133");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b57d5162-6890-40d8-8d78-642ef56174e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c97ea114-4b62-456e-971f-57ff28076d92");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98f81a71-c87e-492e-a09d-f70c63ff3a85", "28577d52-f0f9-45c6-b756-5be778a386ba", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0f80c13-8d2d-4762-bd0a-ca1e516e8289", "05237014-dda2-4d43-a46f-b8a26fc35493", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95951798-062c-4705-94f1-91ad28128d29", "1f12ccdf-4880-4383-b2ba-4a304d2d7456", "GroupAdmin", "GROUPADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95951798-062c-4705-94f1-91ad28128d29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f81a71-c87e-492e-a09d-f70c63ff3a85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0f80c13-8d2d-4762-bd0a-ca1e516e8289");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c97ea114-4b62-456e-971f-57ff28076d92", "99217092-39b8-400e-8225-0081efd2b24c", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b57d5162-6890-40d8-8d78-642ef56174e2", "cac1c9ba-2b4c-42ea-8f2b-f31e35438584", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "484cc765-a4e2-4f2a-8f58-570754303133", "818c0e4e-740f-4fe0-89c8-b93964ae7aea", "GroupAdmin", "GROUPADMIN" });
        }
    }
}
