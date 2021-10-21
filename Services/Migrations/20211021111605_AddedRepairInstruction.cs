using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Services.Migrations
{
    public partial class AddedRepairInstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairInstructions",
                columns: table => new
                {
                    RepairInstructionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RepairCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairInstructions", x => x.RepairInstructionId);
                    table.ForeignKey(
                        name: "FK_RepairInstructions_RepairCategories_RepairCategoryId",
                        column: x => x.RepairCategoryId,
                        principalTable: "RepairCategories",
                        principalColumn: "RepairCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairInstructions_RepairHeader_RepairHeaderId",
                        column: x => x.RepairHeaderId,
                        principalTable: "RepairHeader",
                        principalColumn: "RepairHeaderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairInstructions_WorkAreas_WorkAreaId",
                        column: x => x.WorkAreaId,
                        principalTable: "WorkAreas",
                        principalColumn: "WorkAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairInstructions_RepairCategoryId",
                table: "RepairInstructions",
                column: "RepairCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairInstructions_RepairHeaderId",
                table: "RepairInstructions",
                column: "RepairHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairInstructions_WorkAreaId",
                table: "RepairInstructions",
                column: "WorkAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairInstructions");
        }
    }
}
