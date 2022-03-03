using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageAmericaAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occurences",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedByUserId = table.Column<long>(nullable: false),
                    DeletedDatetime = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<long>(nullable: false),
                    CreatedDatetime = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<long>(nullable: false),
                    ModifiedDatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<long>(nullable: false),
                    DeletedDatetime = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDatetime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    ModifiedDatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                });

            migrationBuilder.CreateTable(
                name: "weekdays",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDatetime = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<long>(nullable: false),
                    CreatedDatetime = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<long>(nullable: false),
                    ModifiedDatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weekdays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Availablities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeFrom = table.Column<DateTime>(nullable: false),
                    TimeTo = table.Column<DateTime>(nullable: false),
                    IsOccurence = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    DeletedByUserId = table.Column<long>(nullable: false),
                    DeletedDatetime = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<long>(nullable: false),
                    CreatedDatetime = table.Column<DateTime>(nullable: false),
                    ModifiedByUserId = table.Column<long>(nullable: false),
                    ModifiedDatetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availablities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availablities_Occurences_Id",
                        column: x => x.Id,
                        principalTable: "Occurences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledMeetings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProspectName = table.Column<string>(nullable: false),
                    ProspectEmail = table.Column<string>(nullable: false),
                    ProspectPhone = table.Column<string>(nullable: false),
                    ProspectRemarks = table.Column<string>(nullable: true),
                    MeetingDuration = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    ManagerMeetingNotes = table.Column<string>(nullable: true),
                    IsCancelled = table.Column<bool>(nullable: false),
                    CancelledBy = table.Column<long>(nullable: false),
                    CancelledDateTime = table.Column<DateTime>(nullable: false),
                    RescheduledMeetingBy = table.Column<long>(nullable: false),
                    RescheduledMeetingDateTime = table.Column<DateTime>(nullable: false),
                    ProspectCancelRemarks = table.Column<string>(nullable: true),
                    ManagerCancelRemarks = table.Column<string>(nullable: true),
                    PropertyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledMeetings_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledMeetings_PropertyId",
                table: "ScheduledMeetings",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availablities");

            migrationBuilder.DropTable(
                name: "ScheduledMeetings");

            migrationBuilder.DropTable(
                name: "weekdays");

            migrationBuilder.DropTable(
                name: "Occurences");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
