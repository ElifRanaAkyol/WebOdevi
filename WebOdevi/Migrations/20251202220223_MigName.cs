using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdevi.Migrations
{
    /// <inheritdoc />
    public partial class MigName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_userId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Service_serviceId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Trainer_trainerId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Trainer_trainerId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_FitnessCenter_fitnessCenterId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_FitnessCenter_fitnessCenterId",
                table: "Trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerService_Service_serviceId",
                table: "TrainerService");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerService_Trainer_trainerId",
                table: "TrainerService");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecialization_Specialization_specializationId",
                table: "TrainerSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecialization_Trainer_trainerId",
                table: "TrainerSpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerSpecialization",
                table: "TrainerSpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerService",
                table: "TrainerService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainer",
                table: "Trainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCenter",
                table: "FitnessCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Availability",
                table: "Availability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "TrainerSpecialization",
                newName: "TrainerSpecializations");

            migrationBuilder.RenameTable(
                name: "TrainerService",
                newName: "TrainerServices");

            migrationBuilder.RenameTable(
                name: "Trainer",
                newName: "Trainers");

            migrationBuilder.RenameTable(
                name: "Specialization",
                newName: "Specializations");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "FitnessCenter",
                newName: "FitnessCenters");

            migrationBuilder.RenameTable(
                name: "Availability",
                newName: "Availabilities");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TrainerSpecializations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "specializationId",
                table: "TrainerSpecializations",
                newName: "SpecializationId");

            migrationBuilder.RenameColumn(
                name: "trainerId",
                table: "TrainerSpecializations",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerSpecialization_specializationId",
                table: "TrainerSpecializations",
                newName: "IX_TrainerSpecializations_SpecializationId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TrainerServices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "serviceId",
                table: "TrainerServices",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "trainerId",
                table: "TrainerServices",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerService_serviceId",
                table: "TrainerServices",
                newName: "IX_TrainerServices_ServiceId");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Trainers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "fitnessCenterId",
                table: "Trainers",
                newName: "FitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Trainers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Trainer_fitnessCenterId",
                table: "Trainers",
                newName: "IX_Trainers_FitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Specializations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Specializations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "serviceDuration",
                table: "Services",
                newName: "ServiceDuration");

            migrationBuilder.RenameColumn(
                name: "fitnessCenterId",
                table: "Services",
                newName: "FitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Services",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Service_fitnessCenterId",
                table: "Services",
                newName: "IX_Services_FitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "FitnessCenters",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "FitnessCenters",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FitnessCenters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "trainerId",
                table: "Availabilities",
                newName: "TrainerId");

            migrationBuilder.RenameColumn(
                name: "dayOfWeek",
                table: "Availabilities",
                newName: "DayOfWeek");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Availabilities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Availability_trainerId",
                table: "Availabilities",
                newName: "IX_Availabilities_TrainerId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "trainerId",
                table: "Appointments",
                newName: "TrainerId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Appointments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "serviceId",
                table: "Appointments",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "appointmentStartTime",
                table: "Appointments",
                newName: "AppointmentStartTime");

            migrationBuilder.RenameColumn(
                name: "appointmentEndTime",
                table: "Appointments",
                newName: "AppointmentEndTime");

            migrationBuilder.RenameColumn(
                name: "appointmentDuration",
                table: "Appointments",
                newName: "AppointmentDuration");

            migrationBuilder.RenameColumn(
                name: "appointmentDate",
                table: "Appointments",
                newName: "AppointmentDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Appointments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_userId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_trainerId",
                table: "Appointments",
                newName: "IX_Appointments_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_serviceId",
                table: "Appointments",
                newName: "IX_Appointments_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerSpecializations",
                table: "TrainerSpecializations",
                columns: new[] { "TrainerId", "SpecializationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerServices",
                table: "TrainerServices",
                columns: new[] { "TrainerId", "ServiceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCenters",
                table: "FitnessCenters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Availabilities",
                table: "Availabilities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Trainers_TrainerId",
                table: "Appointments",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Trainers_TrainerId",
                table: "Availabilities",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FitnessCenters_FitnessCenterId",
                table: "Services",
                column: "FitnessCenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_FitnessCenters_FitnessCenterId",
                table: "Trainers",
                column: "FitnessCenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerServices_Services_ServiceId",
                table: "TrainerServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerServices_Trainers_TrainerId",
                table: "TrainerServices",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecializations_Specializations_SpecializationId",
                table: "TrainerSpecializations",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecializations_Trainers_TrainerId",
                table: "TrainerSpecializations",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Trainers_TrainerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Trainers_TrainerId",
                table: "Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_FitnessCenters_FitnessCenterId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_FitnessCenters_FitnessCenterId",
                table: "Trainers");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerServices_Services_ServiceId",
                table: "TrainerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerServices_Trainers_TrainerId",
                table: "TrainerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecializations_Specializations_SpecializationId",
                table: "TrainerSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecializations_Trainers_TrainerId",
                table: "TrainerSpecializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerSpecializations",
                table: "TrainerSpecializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerServices",
                table: "TrainerServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCenters",
                table: "FitnessCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Availabilities",
                table: "Availabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "TrainerSpecializations",
                newName: "TrainerSpecialization");

            migrationBuilder.RenameTable(
                name: "TrainerServices",
                newName: "TrainerService");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Trainer");

            migrationBuilder.RenameTable(
                name: "Specializations",
                newName: "Specialization");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "FitnessCenters",
                newName: "FitnessCenter");

            migrationBuilder.RenameTable(
                name: "Availabilities",
                newName: "Availability");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TrainerSpecialization",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SpecializationId",
                table: "TrainerSpecialization",
                newName: "specializationId");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "TrainerSpecialization",
                newName: "trainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerSpecializations_SpecializationId",
                table: "TrainerSpecialization",
                newName: "IX_TrainerSpecialization_specializationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TrainerService",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "TrainerService",
                newName: "serviceId");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "TrainerService",
                newName: "trainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerServices_ServiceId",
                table: "TrainerService",
                newName: "IX_TrainerService_serviceId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Trainer",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "FitnessCenterId",
                table: "Trainer",
                newName: "fitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trainer",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_FitnessCenterId",
                table: "Trainer",
                newName: "IX_Trainer_fitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specialization",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specialization",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ServiceDuration",
                table: "Service",
                newName: "serviceDuration");

            migrationBuilder.RenameColumn(
                name: "FitnessCenterId",
                table: "Service",
                newName: "fitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Service",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Services_FitnessCenterId",
                table: "Service",
                newName: "IX_Service_fitnessCenterId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FitnessCenter",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "FitnessCenter",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FitnessCenter",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Availability",
                newName: "trainerId");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Availability",
                newName: "dayOfWeek");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Availability",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Availabilities_TrainerId",
                table: "Availability",
                newName: "IX_Availability_trainerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointment",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Appointment",
                newName: "trainerId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Appointment",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Appointment",
                newName: "serviceId");

            migrationBuilder.RenameColumn(
                name: "AppointmentStartTime",
                table: "Appointment",
                newName: "appointmentStartTime");

            migrationBuilder.RenameColumn(
                name: "AppointmentEndTime",
                table: "Appointment",
                newName: "appointmentEndTime");

            migrationBuilder.RenameColumn(
                name: "AppointmentDuration",
                table: "Appointment",
                newName: "appointmentDuration");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointment",
                newName: "appointmentDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointment",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointment",
                newName: "IX_Appointment_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_TrainerId",
                table: "Appointment",
                newName: "IX_Appointment_trainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointment",
                newName: "IX_Appointment_serviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerSpecialization",
                table: "TrainerSpecialization",
                columns: new[] { "trainerId", "specializationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerService",
                table: "TrainerService",
                columns: new[] { "trainerId", "serviceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainer",
                table: "Trainer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCenter",
                table: "FitnessCenter",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Availability",
                table: "Availability",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_userId",
                table: "Appointment",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Service_serviceId",
                table: "Appointment",
                column: "serviceId",
                principalTable: "Service",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Trainer_trainerId",
                table: "Appointment",
                column: "trainerId",
                principalTable: "Trainer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Trainer_trainerId",
                table: "Availability",
                column: "trainerId",
                principalTable: "Trainer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_FitnessCenter_fitnessCenterId",
                table: "Service",
                column: "fitnessCenterId",
                principalTable: "FitnessCenter",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_FitnessCenter_fitnessCenterId",
                table: "Trainer",
                column: "fitnessCenterId",
                principalTable: "FitnessCenter",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerService_Service_serviceId",
                table: "TrainerService",
                column: "serviceId",
                principalTable: "Service",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerService_Trainer_trainerId",
                table: "TrainerService",
                column: "trainerId",
                principalTable: "Trainer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecialization_Specialization_specializationId",
                table: "TrainerSpecialization",
                column: "specializationId",
                principalTable: "Specialization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecialization_Trainer_trainerId",
                table: "TrainerSpecialization",
                column: "trainerId",
                principalTable: "Trainer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
