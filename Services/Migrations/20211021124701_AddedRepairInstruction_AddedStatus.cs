using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddedRepairInstruction_AddedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RepairStatusId",
                table: "RepairInstructions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairInstructions_RepairStatusId",
                table: "RepairInstructions",
                column: "RepairStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairInstructions_RepairStatuses_RepairStatusId",
                table: "RepairInstructions",
                column: "RepairStatusId",
                principalTable: "RepairStatuses",
                principalColumn: "RepairStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairInstructions_RepairStatuses_RepairStatusId",
                table: "RepairInstructions");

            migrationBuilder.DropIndex(
                name: "IX_RepairInstructions_RepairStatusId",
                table: "RepairInstructions");

            migrationBuilder.DropColumn(
                name: "RepairStatusId",
                table: "RepairInstructions");
        }
    }
}
