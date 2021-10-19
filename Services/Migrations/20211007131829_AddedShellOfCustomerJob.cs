using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddedShellOfCustomerJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerJobId",
                table: "DiarySlots",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_DiarySlots_CustomerJobId",
                table: "DiarySlots",
                column: "CustomerJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiarySlots_CustomerJobs_CustomerJobId",
                table: "DiarySlots",
                column: "CustomerJobId",
                principalTable: "CustomerJobs",
                principalColumn: "CustomerJobId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiarySlots_CustomerJobs_CustomerJobId",
                table: "DiarySlots");

            migrationBuilder.DropTable(
                name: "CustomerJobs");

            migrationBuilder.DropIndex(
                name: "IX_DiarySlots_CustomerJobId",
                table: "DiarySlots");

            migrationBuilder.DropColumn(
                name: "CustomerJobId",
                table: "DiarySlots");
        }
    }
}
