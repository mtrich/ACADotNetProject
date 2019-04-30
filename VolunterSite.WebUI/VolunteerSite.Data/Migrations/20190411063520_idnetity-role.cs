using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class idnetityrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50f1725a-85ac-4319-b986-896f3c5dad62", "87be82e4-dc4e-485c-a33e-ebb066f95fd6", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e8a421d-0511-4714-b1f4-242b123166bc", "2bd1decf-f1d5-4a5f-8b6f-201a9ec687eb", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46f05a81-41cf-40fe-8565-42503cf9c698", "1b5bd431-acc9-4a08-aeca-38dbc6e6767c", "GroupAdmin", "GROUPADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e8a421d-0511-4714-b1f4-242b123166bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46f05a81-41cf-40fe-8565-42503cf9c698");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50f1725a-85ac-4319-b986-896f3c5dad62");
        }
    }
}
