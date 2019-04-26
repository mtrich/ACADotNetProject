using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class Addprofilepicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageURL",
                table: "Volunteers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2d73823-71b4-4f12-be42-32f74006a497", "8e4e7717-c121-4080-a013-e12afcf7547d", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7635e068-21da-4869-a8c7-01a5c25db8c8", "211c2108-3f70-42fd-bb4c-3a86cd7bed0e", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31400fe8-83e8-41b9-9d5d-f7185fe18614", "cf628e83-8dfe-4378-a777-6f06e0387cfe", "GroupAdmin", "GROUPADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31400fe8-83e8-41b9-9d5d-f7185fe18614");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7635e068-21da-4869-a8c7-01a5c25db8c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2d73823-71b4-4f12-be42-32f74006a497");

            migrationBuilder.DropColumn(
                name: "ProfileImageURL",
                table: "Volunteers");

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
    }
}
