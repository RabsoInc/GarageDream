using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class LinkedFuelTypeToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FuelTypeId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FuelTypeId",
                table: "Customers",
                column: "FuelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_FuelTypes_FuelTypeId",
                table: "Customers",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "FuelTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_FuelTypes_FuelTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FuelTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Customers");
        }
    }
}
