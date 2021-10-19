﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services;

namespace Services.Migrations
{
    [DbContext(typeof(GarageDreamDbContext))]
    partial class GarageDreamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.BaseModels.CRM.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AddressLine3")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AddressLine4")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Models.BaseModels.CRM.ContactMethodType", b =>
                {
                    b.Property<Guid>("ContactMethodTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactMethodTypeDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ContactMethodTypeId");

                    b.ToTable("ContactMethodTypes");
                });

            modelBuilder.Entity("Models.BaseModels.CRM.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("TitleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerId");

                    b.HasIndex("AddressId");

                    b.HasIndex("GenderId");

                    b.HasIndex("TitleId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.BaseModels.CRM.CustomerContactDetail", b =>
                {
                    b.Property<Guid>("CustomerContactDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("ContactMethodTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerContactDetailId");

                    b.HasIndex("ContactMethodTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerContactDetails");
                });

            modelBuilder.Entity("Models.BaseModels.CRM.Gender", b =>
                {
                    b.Property<Guid>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenderDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Models.BaseModels.CRM.Title", b =>
                {
                    b.Property<Guid>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TitleDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TitleId");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("Models.BaseModels.Diary.DiaryOption", b =>
                {
                    b.Property<Guid>("DiaryOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DiaryNoticeForwardDays")
                        .HasColumnType("int");

                    b.HasKey("DiaryOptionId");

                    b.ToTable("DiaryOptions");
                });

            modelBuilder.Entity("Models.BaseModels.Diary.DiarySlot", b =>
                {
                    b.Property<Guid>("DiarySlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerJobRepairHeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DiaryWorkingDateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("WorkAreaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DiarySlotId");

                    b.HasIndex("CustomerJobRepairHeaderId");

                    b.HasIndex("DiaryWorkingDateId");

                    b.HasIndex("WorkAreaId");

                    b.ToTable("DiarySlots");
                });

            modelBuilder.Entity("Models.BaseModels.Diary.DiaryWorkingDate", b =>
                {
                    b.Property<Guid>("DiaryWorkingDateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Processed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("WorkingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DiaryWorkingDateId");

                    b.ToTable("DiaryWorkingDates");
                });

            modelBuilder.Entity("Models.BaseModels.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Models.BaseModels.Repair.RepairHeader", b =>
                {
                    b.Property<Guid>("RepairHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JobBooked")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("RepairStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RepairHeaderId");

                    b.HasIndex("RepairStatusId");

                    b.HasIndex("VehicleId");

                    b.ToTable("RepairHeader");
                });

            modelBuilder.Entity("Models.BaseModels.Repair.RepairStatus", b =>
                {
                    b.Property<Guid>("RepairStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PrecedenceOrder")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("RepairStatusDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RepairStatusId");

                    b.ToTable("RepairStatuses");
                });

            modelBuilder.Entity("Models.BaseModels.Repair.WorkArea", b =>
                {
                    b.Property<Guid>("WorkAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DefaultUnits")
                        .HasColumnType("int");

                    b.Property<string>("WorkAreaDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkAreaId");

                    b.ToTable("WorkAreas");
                });

            modelBuilder.Entity("Models.BaseModels.System.SystemJob", b =>
                {
                    b.Property<Guid>("SystemJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AutoRunOnStartUp")
                        .HasColumnType("bit");

                    b.Property<string>("ProcedureName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SystemJobDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("SystemJobId");

                    b.ToTable("SystemJobs");
                });

            modelBuilder.Entity("Models.BaseModels.System.SystemJobHistory", b =>
                {
                    b.Property<Guid>("SystemJobHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AutoExecuted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateExecuted")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SystemJobId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SystemJobHistoryId");

                    b.HasIndex("SystemJobId");

                    b.ToTable("SystemJobHistories");
                });

            modelBuilder.Entity("Models.BaseModels.Vehicles.FuelType", b =>
                {
                    b.Property<Guid>("FuelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FuelTypeDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FuelTypeId");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("Models.BaseModels.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FuelTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("VehicleMakeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VehicleModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VehicleId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("VehicleMakeId");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Models.BaseModels.Vehicles.VehicleMake", b =>
                {
                    b.Property<Guid>("VehicleMakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleMakeDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VehicleMakeId");

                    b.ToTable("VehicleMakes");
                });

            modelBuilder.Entity("Models.BaseModels.Vehicles.VehicleModel", b =>
                {
                    b.Property<Guid>("VehicleModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VehicleMakeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleModelDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VehicleModelId");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModels");
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
                    b.HasOne("Models.BaseModels.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.BaseModels.Identity.ApplicationUser", null)
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

                    b.HasOne("Models.BaseModels.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.BaseModels.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.BaseModels.CRM.Customer", b =>
                {
                    b.HasOne("Models.BaseModels.CRM.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Models.BaseModels.CRM.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("Models.BaseModels.CRM.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId");

                    b.Navigation("Address");

                    b.Navigation("Gender");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Models.BaseModels.CRM.CustomerContactDetail", b =>
                {
                    b.HasOne("Models.BaseModels.CRM.ContactMethodType", "ContactMethodType")
                        .WithMany()
                        .HasForeignKey("ContactMethodTypeId");

                    b.HasOne("Models.BaseModels.CRM.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("ContactMethodType");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Models.BaseModels.Diary.DiarySlot", b =>
                {
                    b.HasOne("Models.BaseModels.Repair.RepairHeader", "CustomerJob")
                        .WithMany()
                        .HasForeignKey("CustomerJobRepairHeaderId");

                    b.HasOne("Models.BaseModels.Diary.DiaryWorkingDate", "DiaryWorkingDate")
                        .WithMany()
                        .HasForeignKey("DiaryWorkingDateId");

                    b.HasOne("Models.BaseModels.Repair.WorkArea", "WorkArea")
                        .WithMany()
                        .HasForeignKey("WorkAreaId");

                    b.Navigation("CustomerJob");

                    b.Navigation("DiaryWorkingDate");

                    b.Navigation("WorkArea");
                });

            modelBuilder.Entity("Models.BaseModels.Repair.RepairHeader", b =>
                {
                    b.HasOne("Models.BaseModels.Repair.RepairStatus", "RepairStatus")
                        .WithMany()
                        .HasForeignKey("RepairStatusId");

                    b.HasOne("Models.BaseModels.Vehicles.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("RepairStatus");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Models.BaseModels.System.SystemJobHistory", b =>
                {
                    b.HasOne("Models.BaseModels.System.SystemJob", "SystemJob")
                        .WithMany()
                        .HasForeignKey("SystemJobId");

                    b.Navigation("SystemJob");
                });

            modelBuilder.Entity("Models.BaseModels.Vehicles.Vehicle", b =>
                {
                    b.HasOne("Models.BaseModels.CRM.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Models.BaseModels.Vehicles.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId");

                    b.HasOne("Models.BaseModels.Vehicles.VehicleMake", "VehicleMake")
                        .WithMany()
                        .HasForeignKey("VehicleMakeId");

                    b.HasOne("Models.BaseModels.Vehicles.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId");

                    b.Navigation("Customer");

                    b.Navigation("FuelType");

                    b.Navigation("VehicleMake");

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("Models.BaseModels.Vehicles.VehicleModel", b =>
                {
                    b.HasOne("Models.BaseModels.Vehicles.VehicleMake", "VehicleMake")
                        .WithMany()
                        .HasForeignKey("VehicleMakeId");

                    b.Navigation("VehicleMake");
                });
#pragma warning restore 612, 618
        }
    }
}
