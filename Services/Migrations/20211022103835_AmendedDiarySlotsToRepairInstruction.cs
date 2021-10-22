using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AmendedDiarySlotsToRepairInstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiarySlots_RepairHeader_CustomerJobRepairHeaderId",
                table: "DiarySlots");

            migrationBuilder.RenameColumn(
                name: "CustomerJobRepairHeaderId",
                table: "DiarySlots",
                newName: "RepairInstructionId");

            migrationBuilder.RenameIndex(
                name: "IX_DiarySlots_CustomerJobRepairHeaderId",
                table: "DiarySlots",
                newName: "IX_DiarySlots_RepairInstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiarySlots_RepairInstructions_RepairInstructionId",
                table: "DiarySlots",
                column: "RepairInstructionId",
                principalTable: "RepairInstructions",
                principalColumn: "RepairInstructionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiarySlots_RepairInstructions_RepairInstructionId",
                table: "DiarySlots");

            migrationBuilder.RenameColumn(
                name: "RepairInstructionId",
                table: "DiarySlots",
                newName: "CustomerJobRepairHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_DiarySlots_RepairInstructionId",
                table: "DiarySlots",
                newName: "IX_DiarySlots_CustomerJobRepairHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiarySlots_RepairHeader_CustomerJobRepairHeaderId",
                table: "DiarySlots",
                column: "CustomerJobRepairHeaderId",
                principalTable: "RepairHeader",
                principalColumn: "RepairHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
