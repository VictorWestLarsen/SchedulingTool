using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingTool.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ShiftTodo",
                columns: table => new
                {
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTodo", x => new { x.TodoId, x.ShiftId });
                    table.ForeignKey(
                        name: "FK_ShiftTodo_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftTodo_Todo_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTodo_ShiftId",
                table: "ShiftTodo",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftTodo");

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
    }
}
