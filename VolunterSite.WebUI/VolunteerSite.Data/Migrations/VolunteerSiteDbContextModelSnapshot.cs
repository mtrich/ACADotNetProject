﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolunteerSite.Data.Context;

namespace VolunteerSite.Data.Migrations
{
    [DbContext(typeof(VolunteerSiteDbContext))]
    partial class VolunteerSiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "ab01e8b9-c7a0-4317-96e2-12397f4dbeba",
                            ConcurrencyStamp = "4aa233f2-5ef9-420c-9cf4-38f4e9704765",
                            Name = "Volunteer",
                            NormalizedName = "VOLUNTEER"
                        },
                        new
                        {
                            Id = "a6cb033e-1027-42a6-b160-6ae02fc3b954",
                            ConcurrencyStamp = "d4b6aa5f-1967-463d-9183-36889fbce7b3",
                            Name = "OrganizationAdmin",
                            NormalizedName = "ORGANIZATIONADMIN"
                        },
                        new
                        {
                            Id = "91f0a660-cac1-4a28-8291-c3ddcf1970b3",
                            ConcurrencyStamp = "ad682c8b-f91f-45fc-89e3-882024f7743e",
                            Name = "GroupAdmin",
                            NormalizedName = "GROUPADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("TotalHours");

                    b.Property<int>("VolunteerGroupId");

                    b.Property<int>("VolunteerId");

                    b.HasKey("Id");

                    b.HasIndex("VolunteerGroupId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.JobListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("AppUserId");

                    b.Property<string>("City");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("OrganizationId");

                    b.Property<int>("PositionsAvailable");

                    b.Property<string>("State");

                    b.Property<string>("TypeOfJob");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("JobListings");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Email");

                    b.Property<string>("LogoImageURL");

                    b.Property<string>("OrganizationAdminId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationAdminId")
                        .IsUnique()
                        .HasFilter("[OrganizationAdminId] IS NOT NULL");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.SavedJobListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("VolunteerId");

                    b.HasKey("Id");

                    b.HasIndex("VolunteerId");

                    b.ToTable("SavedJobListing");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int?>("JobListingId");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("SkillsAndExperience");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("JobListingId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.VolunteerGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupAdminId");

                    b.Property<string>("GroupName");

                    b.Property<int?>("VolunteerId");

                    b.HasKey("Id");

                    b.HasIndex("GroupAdminId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("VolunteerGroups");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VolunteerSite.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.GroupMember", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.VolunteerGroup", "VolunteerGroup")
                        .WithMany("GroupMembers")
                        .HasForeignKey("VolunteerGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VolunteerSite.Domain.Models.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.JobListing", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.AppUser")
                        .WithMany("JobListings")
                        .HasForeignKey("AppUserId");

                    b.HasOne("VolunteerSite.Domain.Models.Organization", "Organization")
                        .WithMany("JobListings")
                        .HasForeignKey("OrganizationId")
                        .HasConstraintName("ForeignKey_JobListing_Organization")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.Organization", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.AppUser", "OrganizationAdmin")
                        .WithOne("Organization")
                        .HasForeignKey("VolunteerSite.Domain.Models.Organization", "OrganizationAdminId")
                        .HasConstraintName("ForeignKey_Organization_AppUser");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.SavedJobListing", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.Volunteer", "Volunteer")
                        .WithMany("SavedJobListings")
                        .HasForeignKey("VolunteerId")
                        .HasConstraintName("ForeignKey_SavedJobListing_Volunteer")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.Volunteer", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.JobListing")
                        .WithMany("Volunteers")
                        .HasForeignKey("JobListingId");

                    b.HasOne("VolunteerSite.Domain.Models.AppUser", "User")
                        .WithOne("Volunteer")
                        .HasForeignKey("VolunteerSite.Domain.Models.Volunteer", "UserId");
                });

            modelBuilder.Entity("VolunteerSite.Domain.Models.VolunteerGroup", b =>
                {
                    b.HasOne("VolunteerSite.Domain.Models.AppUser", "GroupAdmin")
                        .WithMany("VolunteerGroups")
                        .HasForeignKey("GroupAdminId")
                        .HasConstraintName("ForeignKey_VolunteerGroup_AppUser");

                    b.HasOne("VolunteerSite.Domain.Models.Volunteer")
                        .WithMany("VolunteerGroups")
                        .HasForeignKey("VolunteerId");
                });
#pragma warning restore 612, 618
        }
    }
}
