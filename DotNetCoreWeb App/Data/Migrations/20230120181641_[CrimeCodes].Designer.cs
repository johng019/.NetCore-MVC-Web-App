﻿// <auto-generated />
using System;
using DotNetCoreWeb_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCoreWeb_App.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230120181641_[CrimeCodes]")]
    partial class CrimeCodes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreWeb_App.Models.Aliases", b =>
                {
                    b.Property<int>("alias_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("criminal_id")
                        .HasColumnType("int");

                    b.HasKey("alias_id");

                    b.ToTable("Aliases");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.Appeals", b =>
                {
                    b.Property<int>("appeal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("crime_id")
                        .HasColumnType("int");

                    b.Property<string>("filing_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hearing_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("appeal_id");

                    b.ToTable("Appeals");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.CrimeCodes", b =>
                {
                    b.Property<int>("crime_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code_description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("crime_code");

                    b.ToTable("CrimeCodes");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.CrimeOfficers", b =>
                {
                    b.Property<int>("crime_officer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("crime_id")
                        .HasColumnType("int");

                    b.Property<int>("officer_id")
                        .HasColumnType("int");

                    b.HasKey("crime_officer_id");

                    b.ToTable("CrimeOfficers");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.Crime_charges", b =>
                {
                    b.Property<int>("charge_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("amount_paid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("charge_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("court_fee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("crime_code")
                        .HasColumnType("int");

                    b.Property<int>("crime_id")
                        .HasColumnType("int");

                    b.Property<string>("fine_amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pay_due_date")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("charge_id");

                    b.ToTable("Crime_charges");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.Crimes", b =>
                {
                    b.Property<int>("crime_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("appeal_cut_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("criminal_id")
                        .HasColumnType("int");

                    b.Property<string>("date_charged")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_recorded")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hearing_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("crime_id");

                    b.ToTable("Crimes");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.Criminals", b =>
                {
                    b.Property<int>("criminal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("p_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("v_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("criminal_id");

                    b.ToTable("Criminals");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.CriminalsDW", b =>
                {
                    b.Property<int>("criminal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("p_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("v_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("criminal_id");

                    b.ToTable("CriminalsDW");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.Officers", b =>
                {
                    b.Property<int>("officer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("badge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("precinct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("officer_id");

                    b.ToTable("Officers");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.ProbationContact", b =>
                {
                    b.Property<int>("probation_contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("con_freq")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("high_amt")
                        .HasColumnType("int");

                    b.Property<int>("low_amt")
                        .HasColumnType("int");

                    b.Property<int>("prob_cat")
                        .HasColumnType("int");

                    b.HasKey("probation_contact_id");

                    b.ToTable("ProbationContact");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.ProbationOfficers", b =>
                {
                    b.Property<int>("prob_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mgr_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pager_num")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("prob_id");

                    b.ToTable("ProbationOfficers");
                });

            modelBuilder.Entity("DotNetCoreWeb_App.Models.Sentences", b =>
                {
                    b.Property<int>("sentence_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("criminal_id")
                        .HasColumnType("int");

                    b.Property<string>("end_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prob_id")
                        .HasColumnType("int");

                    b.Property<string>("start_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("violations")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sentence_id");

                    b.ToTable("Sentences");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
