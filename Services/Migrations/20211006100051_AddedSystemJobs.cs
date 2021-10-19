using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddedSystemJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemJobs",
                columns: table => new
                {
                    SystemJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemJobDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AutoRunOnStartUp = table.Column<bool>(type: "bit", nullable: false),
                    ProcedureName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemJobs", x => x.SystemJobId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemJobs");
        }
    }
}
