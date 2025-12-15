using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdevi.Migrations
{
    /// <inheritdoc />
    public partial class updateFitnessCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_FitnessCenters_FitnessCenterId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_FitnessCenterId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FitnessCenterId",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FitnessCenterId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_FitnessCenterId",
                table: "Services",
                column: "FitnessCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FitnessCenters_FitnessCenterId",
                table: "Services",
                column: "FitnessCenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
