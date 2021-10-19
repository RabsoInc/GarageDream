using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddedDiarySlots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiarySlots",
                columns: table => new
                {
                    DiarySlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaryWorkingDateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiarySlots", x => x.DiarySlotId);
                    table.ForeignKey(
                        name: "FK_DiarySlots_DiaryWorkingDates_DiaryWorkingDateId",
                        column: x => x.DiaryWorkingDateId,
                        principalTable: "DiaryWorkingDates",
                        principalColumn: "DiaryWorkingDateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiarySlots_WorkAreas_WorkAreaId",
                        column: x => x.WorkAreaId,
                        principalTable: "WorkAreas",
                        principalColumn: "WorkAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiarySlots_DiaryWorkingDateId",
                table: "DiarySlots",
                column: "DiaryWorkingDateId");

            migrationBuilder.CreateIndex(
                name: "IX_DiarySlots_WorkAreaId",
                table: "DiarySlots",
                column: "WorkAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiarySlots");
        }
    }
}
