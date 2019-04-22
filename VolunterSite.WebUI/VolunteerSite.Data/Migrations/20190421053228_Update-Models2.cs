using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class UpdateModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17176041-9512-4bb4-b156-a74a2cac219d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a942a42-bed9-42d9-8758-f8d44b1af8a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aaf6b1b-3a67-416a-8e61-e81b395efa56");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Volunteers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cdee0be3-d94e-4f1f-b7c0-c7866f9d1fbc", "1bd74c5d-84a7-48c7-b09d-d985f5eabb9e", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0503221f-436c-4241-9c0a-6455dc321a12", "51da9c45-d36b-4a47-b9c7-4163b840d171", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "775f4eba-d746-4f97-8643-75b115a182bf", "b7b3c54b-8318-4152-aa10-28fc716b9978", "GroupAdmin", "GROUPADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_UserId",
                table: "Volunteers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_AspNetUsers_UserId",
                table: "Volunteers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_AspNetUsers_UserId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_UserId",
                table: "Volunteers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0503221f-436c-4241-9c0a-6455dc321a12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "775f4eba-d746-4f97-8643-75b115a182bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdee0be3-d94e-4f1f-b7c0-c7866f9d1fbc");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Volunteers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3aaf6b1b-3a67-416a-8e61-e81b395efa56", "4354f366-a309-4f4f-9202-d78741affdd6", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a942a42-bed9-42d9-8758-f8d44b1af8a6", "d100600c-19b0-461f-aa98-81289dca66e2", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17176041-9512-4bb4-b156-a74a2cac219d", "a4d4513c-a9d3-401b-ba6b-badb865723d6", "GroupAdmin", "GROUPADMIN" });
        }
    }
}
