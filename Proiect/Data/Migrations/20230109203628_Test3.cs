using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _12dec2022.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Threads_ThreadIdThread",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IdReplyTo",
                table: "Replies");

            migrationBuilder.AlterColumn<int>(
                name: "ThreadIdThread",
                table: "Replies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdReplyTo",
                table: "Replies",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Threads_ThreadIdThread",
                table: "Replies",
                column: "ThreadIdThread",
                principalTable: "Threads",
                principalColumn: "IdThread",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
