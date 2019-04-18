using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class addedOrganizationLogoURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb885a2d-59fd-4a6a-9435-2a75539ec533");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cff343ad-7571-4da8-95c5-5aede8569749");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff811587-1f9d-4b29-9b5f-d5b1c69cdbdd");

            migrationBuilder.AddColumn<string>(
                name: "LogoImageURL",
                table: "Organizations",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "049c2a8e-e3b0-44b0-a32a-2a92f0f68924", "dbf906fa-79e6-43cf-8e66-29cf2bc8efd3", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e19da9b5-6b21-4ece-b3c6-a2ee4b722f0c", "fe632dd9-7b3c-49de-967f-e99c4faaf567", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62c6ebb7-3b3c-4b5e-8ba9-8879dc9784e9", "cd3e4f11-7cc3-48ea-ad99-78144642a352", "GroupAdmin", "GROUPADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "049c2a8e-e3b0-44b0-a32a-2a92f0f68924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62c6ebb7-3b3c-4b5e-8ba9-8879dc9784e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19da9b5-6b21-4ece-b3c6-a2ee4b722f0c");

            migrationBuilder.DropColumn(
                name: "LogoImageURL",
                table: "Organizations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb885a2d-59fd-4a6a-9435-2a75539ec533", "01f9f7a3-e140-40aa-bbcd-ea4df7e6f57c", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cff343ad-7571-4da8-95c5-5aede8569749", "0c0f61e1-1e36-440e-bc27-7bee60fccf85", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff811587-1f9d-4b29-9b5f-d5b1c69cdbdd", "b431710a-b73a-4129-b9c8-6723d4fad582", "GroupAdmin", "GROUPADMIN" });
        }
    }
}
