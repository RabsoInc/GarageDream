using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddedVehicleDetails_Typo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicleModels_VehicleMakes_VehicleMakeId",
                table: "vehicleModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicleModels",
                table: "vehicleModels");

            migrationBuilder.RenameTable(
                name: "vehicleModels",
                newName: "VehicleModels");

            migrationBuilder.RenameIndex(
                name: "IX_vehicleModels_VehicleMakeId",
                table: "VehicleModels",
                newName: "IX_VehicleModels_VehicleMakeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleModels",
                table: "VehicleModels",
                column: "VehicleModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId",
                principalTable: "VehicleMakes",
                principalColumn: "VehicleMakeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_VehicleMakes_VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleModels",
                table: "VehicleModels");

            migrationBuilder.RenameTable(
                name: "VehicleModels",
                newName: "vehicleModels");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleModels_VehicleMakeId",
                table: "vehicleModels",
                newName: "IX_vehicleModels_VehicleMakeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicleModels",
                table: "vehicleModels",
                column: "VehicleModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicleModels_VehicleMakes_VehicleMakeId",
                table: "vehicleModels",
                column: "VehicleMakeId",
                principalTable: "VehicleMakes",
                principalColumn: "VehicleMakeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
