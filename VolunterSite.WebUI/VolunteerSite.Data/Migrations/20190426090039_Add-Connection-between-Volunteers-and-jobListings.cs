using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class AddConnectionbetweenVolunteersandjobListings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_JobListings_JobListingId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_JobListingId",
                table: "Volunteers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobListing",
                table: "SavedJobListing");

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
                name: "JobListingId",
                table: "Volunteers");

            migrationBuilder.RenameTable(
                name: "SavedJobListing",
                newName: "SavedJobListings");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobListing_VolunteerId",
                table: "SavedJobListings",
                newName: "IX_SavedJobListings_VolunteerId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SavedJobListings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "SavedJobListings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobListingId",
                table: "SavedJobListings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "SavedJobListings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "SavedJobListings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobListings",
                table: "SavedJobListings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e367ee6-fbfc-416f-a63d-f84b578c844a", "6575ba14-cd13-4d08-b598-856a75ade05d", "Volunteer", "VOLUNTEER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cf441ea-976c-4fa9-bbcf-c63e76578407", "a7a69ccf-597a-4620-bfe5-084e272359be", "OrganizationAdmin", "ORGANIZATIONADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobListings_JobListingId",
                table: "SavedJobListings",
                column: "JobListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobListings_JobListings_JobListingId",
                table: "SavedJobListings",
                column: "JobListingId",
                principalTable: "JobListings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobListings_JobListings_JobListingId",
                table: "SavedJobListings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobListings",
                table: "SavedJobListings");

            migrationBuilder.DropIndex(
                name: "IX_SavedJobListings_JobListingId",
                table: "SavedJobListings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cf441ea-976c-4fa9-bbcf-c63e76578407");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e367ee6-fbfc-416f-a63d-f84b578c844a");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SavedJobListings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "SavedJobListings");

            migrationBuilder.DropColumn(
                name: "JobListingId",
                table: "SavedJobListings");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "SavedJobListings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "SavedJobListings");

            migrationBuilder.RenameTable(
                name: "SavedJobListings",
                newName: "SavedJobListing");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobListings_VolunteerId",
                table: "SavedJobListing",
                newName: "IX_SavedJobListing_VolunteerId");

            migrationBuilder.AddColumn<int>(
                name: "JobListingId",
                table: "Volunteers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobListing",
                table: "SavedJobListing",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_JobListingId",
                table: "Volunteers",
                column: "JobListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_JobListings_JobListingId",
                table: "Volunteers",
                column: "JobListingId",
                principalTable: "JobListings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
