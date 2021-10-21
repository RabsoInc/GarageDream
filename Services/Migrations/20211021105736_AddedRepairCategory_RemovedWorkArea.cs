using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Services.Migrations
{
    public partial class AddedRepairCategory_RemovedWorkArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairCategories_WorkAreas_WorkAreaId",
                table: "RepairCategories");

            migrationBuilder.DropIndex(
                name: "IX_RepairCategories_WorkAreaId",
                table: "RepairCategories");

            migrationBuilder.DropColumn(
                name: "WorkAreaId",
                table: "RepairCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkAreaId",
                table: "RepairCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairCategories_WorkAreaId",
                table: "RepairCategories",
                column: "WorkAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairCategories_WorkAreas_WorkAreaId",
                table: "RepairCategories",
                column: "WorkAreaId",
                principalTable: "WorkAreas",
                principalColumn: "WorkAreaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
