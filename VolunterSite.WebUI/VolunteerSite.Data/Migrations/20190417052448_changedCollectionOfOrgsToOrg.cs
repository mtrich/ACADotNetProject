using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class changedCollectionOfOrgsToOrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrganizationAdminId",
                table: "Organizations");

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

            migrationBuilder.AddColumn<int>(
                name: "VolunteerId",
                table: "VolunteerGroups",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SkillsAndExperience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

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
                name: "IX_VolunteerGroups_VolunteerId",
                table: "VolunteerGroups",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationAdminId",
                table: "Organizations",
                column: "OrganizationAdminId",
                unique: true,
                filter: "[OrganizationAdminId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerGroups_Volunteers_VolunteerId",
                table: "VolunteerGroups",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerGroups_Volunteers_VolunteerId",
                table: "VolunteerGroups");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerGroups_VolunteerId",
                table: "VolunteerGroups");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrganizationAdminId",
                table: "Organizations");

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
                name: "VolunteerId",
                table: "VolunteerGroups");

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

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationAdminId",
                table: "Organizations",
                column: "OrganizationAdminId");
        }
    }
}
