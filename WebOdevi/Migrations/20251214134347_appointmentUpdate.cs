using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdevi.Migrations
{
    /// <inheritdoc />
    public partial class appointmentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDuration",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentEndTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentStartTime",
                table: "Appointments",
                newName: "DayOfWeek");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointments",
                newName: "Hour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Appointments",
                newName: "AppointmentDate");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Appointments",
                newName: "AppointmentStartTime");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentDuration",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentEndTime",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
