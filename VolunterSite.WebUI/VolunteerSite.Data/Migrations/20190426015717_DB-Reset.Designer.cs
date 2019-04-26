﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolunteerSite.Data.Context;

namespace VolunteerSite.Data.Migrations
{
    [DbContext(typeof(VolunteerSiteDbContext))]
    [Migration("20190426015717_DB-Reset")]
    partial class DBReset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = "9ab9962d-2bb2-4b32-a175-869c07de2f99",
                            ConcurrencyStamp = "3f2b287a-45c1-46ca-a04b-9f7501f55bad",
                            Name = "Volunteer",
                            NormalizedName = "VOLUNTEER"
                        },
                        new
                        {
                            Id = "e0286461-3eb8-4f6c-b882-c1ae5c40c1a9",
                            ConcurrencyStamp = "e57da016-03c2-4633-a15d-87133384b739",
                            Name = "OrganizationAdmin",
                            NormalizedName = "ORGANIZATIONADMIN"
                        },
                        new
                        {
                            Id = "7368a485-215f-43d1-9648-d0e143fc47aa",
                            ConcurrencyStamp = "ee7026a2-7f73-4c70-8381-3740b2d47c3a",
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
