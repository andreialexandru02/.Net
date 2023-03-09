using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _12dec2022.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migratie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThreadIdThread",
                table: "Replies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ThreadIdThread",
                table: "Replies",
                column: "ThreadIdThread");

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

            migrationBuilder.DropIndex(
                name: "IX_Replies_ThreadIdThread",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "ThreadIdThread",
                table: "Replies");
        }
    }
}
