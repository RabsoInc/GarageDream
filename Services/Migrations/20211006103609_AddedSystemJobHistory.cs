using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Services.Migrations
{
    public partial class AddedSystemJobHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemJobHistories",
                columns: table => new
                {
                    SystemJobHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateExecuted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutoExecuted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemJobHistories", x => x.SystemJobHistoryId);
                    table.ForeignKey(
                        name: "FK_SystemJobHistories_SystemJobs_SystemJobId",
                        column: x => x.SystemJobId,
                        principalTable: "SystemJobs",
                        principalColumn: "SystemJobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemJobHistories_SystemJobId",
                table: "SystemJobHistories",
                column: "SystemJobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemJobHistories");
        }
    }
}
