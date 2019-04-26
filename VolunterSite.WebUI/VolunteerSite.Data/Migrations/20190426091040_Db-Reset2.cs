using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class DbReset2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cf441ea-976c-4fa9-bbcf-c63e76578407");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e367ee6-fbfc-416f-a63d-f84b578c844a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8e7c7b0-a8b4-451a-9bc5-151a68d15e0b", "77af6a6d-2996-4727-ae99-e4dbea0922ce", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53968156-86e4-4d02-b3d1-e06589ff4111", "0d7b241d-17a0-4633-b52a-372ddce99c5b", "OrganizationAdmin", "ORGANIZATIONADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53968156-86e4-4d02-b3d1-e06589ff4111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e7c7b0-a8b4-451a-9bc5-151a68d15e0b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e367ee6-fbfc-416f-a63d-f84b578c844a", "6575ba14-cd13-4d08-b598-856a75ade05d", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cf441ea-976c-4fa9-bbcf-c63e76578407", "a7a69ccf-597a-4620-bfe5-084e272359be", "OrganizationAdmin", "ORGANIZATIONADMIN" });
        }
    }
}
