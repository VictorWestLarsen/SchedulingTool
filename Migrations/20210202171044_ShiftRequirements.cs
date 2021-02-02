using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingTool.Migrations
{
    public partial class ShiftRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Shift_AddToShiftId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_AddToShiftId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "AddToShiftId",
                table: "Todo");

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Todo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_ShiftId",
                table: "Todo",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Shift_ShiftId",
                table: "Todo",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Shift_ShiftId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_ShiftId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Todo");

            migrationBuilder.AddColumn<int>(
                name: "AddToShiftId",
                table: "Todo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_AddToShiftId",
                table: "Todo",
                column: "AddToShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Shift_AddToShiftId",
                table: "Todo",
                column: "AddToShiftId",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
