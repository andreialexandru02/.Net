using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _12dec2022.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Threads_ThreadIdThread",
                table: "Replies");

            migrationBuilder.AlterColumn<int>(
                name: "ThreadIdThread",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Threads_ThreadIdThread",
                table: "Replies",
                column: "ThreadIdThread",
                principalTable: "Threads",
                principalColumn: "IdThread",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Threads_ThreadIdThread",
                table: "Replies");

            migrationBuilder.AlterColumn<int>(
                name: "ThreadIdThread",
                table: "Replies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Threads_ThreadIdThread",
                table: "Replies",
                column: "ThreadIdThread",
                principalTable: "Threads",
                principalColumn: "IdThread");
        }
    }
}
