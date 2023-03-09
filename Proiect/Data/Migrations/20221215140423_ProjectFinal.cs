using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _12dec2022.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryIdCategory",
                table: "Threads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Threads_CategoryIdCategory",
                table: "Threads",
                column: "CategoryIdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Categories_CategoryIdCategory",
                table: "Threads",
                column: "CategoryIdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Categories_CategoryIdCategory",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Threads_CategoryIdCategory",
                table: "Threads");

            migrationBuilder.DropColumn(
                name: "CategoryIdCategory",
                table: "Threads");
        }
    }
}
