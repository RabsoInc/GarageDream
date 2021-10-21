using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Services.Migrations
{
    public partial class AddedRepairCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairCategories",
                columns: table => new
                {
                    RepairCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairCategoryDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WorkAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairCategories", x => x.RepairCategoryId);
                    table.ForeignKey(
                        name: "FK_RepairCategories_WorkAreas_WorkAreaId",
                        column: x => x.WorkAreaId,
                        principalTable: "WorkAreas",
                        principalColumn: "WorkAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairCategories_WorkAreaId",
                table: "RepairCategories",
                column: "WorkAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairCategories");
        }
    }
}
