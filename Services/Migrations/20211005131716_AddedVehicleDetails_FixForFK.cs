using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class AddedVehicleDetails_FixForFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleMake",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleModel",
                table: "Vehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleMakeId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleModelId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleMakeId",
                table: "Vehicles",
                column: "VehicleMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleMakes_VehicleMakeId",
                table: "Vehicles",
                column: "VehicleMakeId",
                principalTable: "VehicleMakes",
                principalColumn: "VehicleMakeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "VehicleModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleMakes_VehicleMakeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleMakeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleMakeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleModelId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "VehicleMake",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleModel",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
