using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class Addedconnectionbetweengroupmembersandvolunteergroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_VolunteerGroups_VolunteerGroupId1",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_VolunteerGroupId1",
                table: "GroupMembers");

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

            migrationBuilder.DropColumn(
                name: "VolunteerGroupId1",
                table: "GroupMembers");

            migrationBuilder.AlterColumn<int>(
                name: "VolunteerGroupId",
                table: "GroupMembers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolunteerId",
                table: "GroupMembers",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_VolunteerGroupId",
                table: "GroupMembers",
                column: "VolunteerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_VolunteerId",
                table: "GroupMembers",
                column: "VolunteerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_VolunteerGroups_VolunteerGroupId",
                table: "GroupMembers",
                column: "VolunteerGroupId",
                principalTable: "VolunteerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Volunteers_VolunteerId",
                table: "GroupMembers",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_VolunteerGroups_VolunteerGroupId",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Volunteers_VolunteerId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_VolunteerGroupId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_VolunteerId",
                table: "GroupMembers");

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

            migrationBuilder.DropColumn(
                name: "VolunteerId",
                table: "GroupMembers");

            migrationBuilder.AlterColumn<string>(
                name: "VolunteerGroupId",
                table: "GroupMembers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VolunteerGroupId1",
                table: "GroupMembers",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_VolunteerGroupId1",
                table: "GroupMembers",
                column: "VolunteerGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_VolunteerGroups_VolunteerGroupId1",
                table: "GroupMembers",
                column: "VolunteerGroupId1",
                principalTable: "VolunteerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
