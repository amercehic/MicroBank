using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Infrastructure.Migrations
{
    public partial class ClientApplicationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientApplicationAddressData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(maxLength: 100, nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    Province = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientApplicationAddressData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientApplicationContactData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientApplicationContactData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientApplicationFamilyDetailsData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfMembers = table.Column<int>(nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 50, nullable: false),
                    NumberOfDependents = table.Column<int>(nullable: false),
                    NumberOfChildren = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientApplicationFamilyDetailsData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PersonalId = table.Column<string>(maxLength: 20, nullable: false),
                    OfficeId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    SubmittedOnDate = table.Column<DateTime>(nullable: false),
                    ClientApplicationAddressDataId = table.Column<int>(nullable: true),
                    ClientApplicationFamilyDetailsDataId = table.Column<int>(nullable: true),
                    ClientApplicationContactDataId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientApplications_ClientApplicationAddressData_ClientApplicationAddressDataId",
                        column: x => x.ClientApplicationAddressDataId,
                        principalTable: "ClientApplicationAddressData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientApplications_ClientApplicationContactData_ClientApplicationContactDataId",
                        column: x => x.ClientApplicationContactDataId,
                        principalTable: "ClientApplicationContactData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientApplications_ClientApplicationFamilyDetailsData_ClientApplicationFamilyDetailsDataId",
                        column: x => x.ClientApplicationFamilyDetailsDataId,
                        principalTable: "ClientApplicationFamilyDetailsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientApplications_ClientApplicationAddressDataId",
                table: "ClientApplications",
                column: "ClientApplicationAddressDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientApplications_ClientApplicationContactDataId",
                table: "ClientApplications",
                column: "ClientApplicationContactDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientApplications_ClientApplicationFamilyDetailsDataId",
                table: "ClientApplications",
                column: "ClientApplicationFamilyDetailsDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientApplications");

            migrationBuilder.DropTable(
                name: "ClientApplicationAddressData");

            migrationBuilder.DropTable(
                name: "ClientApplicationContactData");

            migrationBuilder.DropTable(
                name: "ClientApplicationFamilyDetailsData");
        }
    }
}
