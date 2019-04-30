using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolunteerSite.Data.Migrations
{
    public partial class identityprovider2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_AspNetUsers_AppUserId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerGroups_AspNetUsers_AppUserId",
                table: "VolunteerGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerGroups_Volunteer_GroupOwnerId1",
                table: "VolunteerGroups");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerGroups_AppUserId",
                table: "VolunteerGroups");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerGroups_GroupOwnerId1",
                table: "VolunteerGroups");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "VolunteerGroups");

            migrationBuilder.DropColumn(
                name: "GroupOwnerId1",
                table: "VolunteerGroups");

            migrationBuilder.RenameColumn(
                name: "GroupOwnerId",
                table: "VolunteerGroups",
                newName: "GroupAdminId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Organizations",
                newName: "OrganizationAdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_AppUserId",
                table: "Organizations",
                newName: "IX_Organizations_OrganizationAdminId");

            migrationBuilder.AlterColumn<string>(
                name: "GroupAdminId",
                table: "VolunteerGroups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerGroups_GroupAdminId",
                table: "VolunteerGroups",
                column: "GroupAdminId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Organization_AppUser",
                table: "Organizations",
                column: "OrganizationAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_VolunteerGroup_AppUser",
                table: "VolunteerGroups",
                column: "GroupAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Organization_AppUser",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_VolunteerGroup_AppUser",
                table: "VolunteerGroups");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerGroups_GroupAdminId",
                table: "VolunteerGroups");

            migrationBuilder.RenameColumn(
                name: "GroupAdminId",
                table: "VolunteerGroups",
                newName: "GroupOwnerId");

            migrationBuilder.RenameColumn(
                name: "OrganizationAdminId",
                table: "Organizations",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_OrganizationAdminId",
                table: "Organizations",
                newName: "IX_Organizations_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "GroupOwnerId",
                table: "VolunteerGroups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "VolunteerGroups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupOwnerId1",
                table: "VolunteerGroups",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SkillsAndExperience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerGroups_AppUserId",
                table: "VolunteerGroups",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerGroups_GroupOwnerId1",
                table: "VolunteerGroups",
                column: "GroupOwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_AspNetUsers_AppUserId",
                table: "Organizations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerGroups_AspNetUsers_AppUserId",
                table: "VolunteerGroups",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerGroups_Volunteer_GroupOwnerId1",
                table: "VolunteerGroups",
                column: "GroupOwnerId1",
                principalTable: "Volunteer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
