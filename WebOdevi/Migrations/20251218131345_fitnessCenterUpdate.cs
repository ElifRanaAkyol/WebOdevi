using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdevi.Migrations
{
    /// <inheritdoc />
    public partial class fitnessCenterUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FitnessCenterId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FitnessCenterServices",
                columns: table => new
                {
                    fitnessCenterId = table.Column<int>(type: "int", nullable: false),
                    serviceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCenterServices", x => new { x.fitnessCenterId, x.serviceId });
                    table.ForeignKey(
                        name: "FK_FitnessCenterServices_FitnessCenters_fitnessCenterId",
                        column: x => x.fitnessCenterId,
                        principalTable: "FitnessCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FitnessCenterServices_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_FitnessCenterId",
                table: "Services",
                column: "FitnessCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCenterServices_serviceId",
                table: "FitnessCenterServices",
                column: "serviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FitnessCenters_FitnessCenterId",
                table: "Services",
                column: "FitnessCenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_FitnessCenters_FitnessCenterId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "FitnessCenterServices");

            migrationBuilder.DropIndex(
                name: "IX_Services_FitnessCenterId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FitnessCenterId",
                table: "Services");
        }
    }
}
