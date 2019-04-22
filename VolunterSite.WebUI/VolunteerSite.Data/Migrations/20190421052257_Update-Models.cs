using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "JobListingId",
                table: "Volunteers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "JobListings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SavedJobListing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedJobListing", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_SavedJobListing_Volunteer",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_JobListingId",
                table: "Volunteers",
                column: "JobListingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_AppUserId",
                table: "JobListings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobListing_VolunteerId",
                table: "SavedJobListing",
                column: "VolunteerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_AspNetUsers_AppUserId",
                table: "JobListings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_JobListings_JobListingId",
                table: "Volunteers",
                column: "JobListingId",
                principalTable: "JobListings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_AspNetUsers_AppUserId",
                table: "JobListings");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_JobListings_JobListingId",
                table: "Volunteers");

            migrationBuilder.DropTable(
                name: "SavedJobListing");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_JobListingId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_AppUserId",
                table: "JobListings");

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

            migrationBuilder.DropColumn(
                name: "JobListingId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "JobListings");

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
    }
}
