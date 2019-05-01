using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class addedGetByAdminIdMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_Organizations_OrganizationId1",
                table: "JobListings");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_OrganizationId1",
                table: "JobListings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d800cb9-f6a0-4e10-8552-6cbe464f47c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f562495-2125-4a80-86eb-d022459e7ebe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c045d8-71d0-4d60-92c4-a62dfc9642a1");

            migrationBuilder.DropColumn(
                name: "OrganizationId1",
                table: "JobListings");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "JobListings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_OrganizationId",
                table: "JobListings",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_Organizations_OrganizationId",
                table: "JobListings",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_Organizations_OrganizationId",
                table: "JobListings");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_OrganizationId",
                table: "JobListings");

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

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationId",
                table: "JobListings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId1",
                table: "JobListings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d800cb9-f6a0-4e10-8552-6cbe464f47c9", "4641ba13-e79b-4d6d-8148-4354af6fe1b4", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7c045d8-71d0-4d60-92c4-a62dfc9642a1", "210faa9b-7197-40a0-9959-dc97769d3b67", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f562495-2125-4a80-86eb-d022459e7ebe", "6d348504-4a6e-418f-b4b7-6f23739118b6", "GroupAdmin", "GROUPADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_OrganizationId1",
                table: "JobListings",
                column: "OrganizationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_Organizations_OrganizationId1",
                table: "JobListings",
                column: "OrganizationId1",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
