using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class addedjoblistingorganizationconnectiontoDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_Organizations_OrganizationId",
                table: "JobListings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1146c013-9dfe-4498-b7e9-2e735914071a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4d2f3b-2144-4bd7-ac85-c4ffa1cf5987");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2827706-83e8-48c7-8782-8905fb66a56a");

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

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_JobListing_Organization",
                table: "JobListings",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_JobListing_Organization",
                table: "JobListings");

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
                values: new object[] { "6d4d2f3b-2144-4bd7-ac85-c4ffa1cf5987", "2bec6a5e-3d8e-4b30-b309-f47c1db2d12a", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1146c013-9dfe-4498-b7e9-2e735914071a", "94c31631-5bd0-4fde-bd46-6aed4ece3b24", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2827706-83e8-48c7-8782-8905fb66a56a", "da227a8c-2cc8-437e-beb4-b4f319ea1ab5", "GroupAdmin", "GROUPADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_Organizations_OrganizationId",
                table: "JobListings",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
