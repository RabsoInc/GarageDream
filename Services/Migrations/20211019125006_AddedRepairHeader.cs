using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddedRepairHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiarySlots_CustomerJobs_CustomerJobId",
                table: "DiarySlots");

            migrationBuilder.DropTable(
                name: "CustomerJobs");

            migrationBuilder.RenameColumn(
                name: "CustomerJobId",
                table: "DiarySlots",
                newName: "CustomerJobRepairHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_DiarySlots_CustomerJobId",
                table: "DiarySlots",
                newName: "IX_DiarySlots_CustomerJobRepairHeaderId");

            migrationBuilder.CreateTable(
                name: "RepairStatuses",
                columns: table => new
                {
                    RepairStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecedenceOrder = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    RepairStatusDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairStatuses", x => x.RepairStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RepairHeader",
                columns: table => new
                {
                    RepairHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RepairStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobBooked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairHeader", x => x.RepairHeaderId);
                    table.ForeignKey(
                        name: "FK_RepairHeader_RepairStatuses_RepairStatusId",
                        column: x => x.RepairStatusId,
                        principalTable: "RepairStatuses",
                        principalColumn: "RepairStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairHeader_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairHeader_RepairStatusId",
                table: "RepairHeader",
                column: "RepairStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairHeader_VehicleId",
                table: "RepairHeader",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiarySlots_RepairHeader_CustomerJobRepairHeaderId",
                table: "DiarySlots",
                column: "CustomerJobRepairHeaderId",
                principalTable: "RepairHeader",
                principalColumn: "RepairHeaderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiarySlots_RepairHeader_CustomerJobRepairHeaderId",
                table: "DiarySlots");

            migrationBuilder.DropTable(
                name: "RepairHeader");

            migrationBuilder.DropTable(
                name: "RepairStatuses");

            migrationBuilder.RenameColumn(
                name: "CustomerJobRepairHeaderId",
                table: "DiarySlots",
                newName: "CustomerJobId");

            migrationBuilder.RenameIndex(
                name: "IX_DiarySlots_CustomerJobRepairHeaderId",
                table: "DiarySlots",
                newName: "IX_DiarySlots_CustomerJobId");

            migrationBuilder.CreateTable(
                name: "CustomerJobs",
                columns: table => new
                {
                    CustomerJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerJobs", x => x.CustomerJobId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DiarySlots_CustomerJobs_CustomerJobId",
                table: "DiarySlots",
                column: "CustomerJobId",
                principalTable: "CustomerJobs",
                principalColumn: "CustomerJobId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
