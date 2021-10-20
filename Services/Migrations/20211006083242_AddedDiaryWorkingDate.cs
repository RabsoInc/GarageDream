using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Services.Migrations
{
    public partial class AddedDiaryWorkingDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryWorkingDates",
                columns: table => new
                {
                    DiaryWorkingDateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryWorkingDates", x => x.DiaryWorkingDateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryWorkingDates");
        }
    }
}
