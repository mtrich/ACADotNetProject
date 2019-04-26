using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class DBReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91f0a660-cac1-4a28-8291-c3ddcf1970b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cb033e-1027-42a6-b160-6ae02fc3b954");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab01e8b9-c7a0-4317-96e2-12397f4dbeba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ab9962d-2bb2-4b32-a175-869c07de2f99", "3f2b287a-45c1-46ca-a04b-9f7501f55bad", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0286461-3eb8-4f6c-b882-c1ae5c40c1a9", "e57da016-03c2-4633-a15d-87133384b739", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7368a485-215f-43d1-9648-d0e143fc47aa", "ee7026a2-7f73-4c70-8381-3740b2d47c3a", "GroupAdmin", "GROUPADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7368a485-215f-43d1-9648-d0e143fc47aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ab9962d-2bb2-4b32-a175-869c07de2f99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0286461-3eb8-4f6c-b882-c1ae5c40c1a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab01e8b9-c7a0-4317-96e2-12397f4dbeba", "4aa233f2-5ef9-420c-9cf4-38f4e9704765", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6cb033e-1027-42a6-b160-6ae02fc3b954", "d4b6aa5f-1967-463d-9183-36889fbce7b3", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91f0a660-cac1-4a28-8291-c3ddcf1970b3", "ad682c8b-f91f-45fc-89e3-882024f7743e", "GroupAdmin", "GROUPADMIN" });
        }
    }
}
