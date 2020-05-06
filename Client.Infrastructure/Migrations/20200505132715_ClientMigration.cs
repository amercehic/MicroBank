using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Infrastructure.Migrations
{
    public partial class ClientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientAddressData",
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
                    table.PrimaryKey("PK_ClientAddressData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientContactData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContactData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientFamilyDetailsData",
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
                    table.PrimaryKey("PK_ClientFamilyDetailsData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    ClientApplicationId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PersonalId = table.Column<string>(maxLength: 20, nullable: false),
                    OfficeId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    SubmittedOnDate = table.Column<DateTime>(nullable: false),
                    ClientAddressDataId = table.Column<int>(nullable: true),
                    ClientFamilyDetailsDataId = table.Column<int>(nullable: true),
                    ClientContactDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientAddressData_ClientAddressDataId",
                        column: x => x.ClientAddressDataId,
                        principalTable: "ClientAddressData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_ClientApplications_ClientApplicationId",
                        column: x => x.ClientApplicationId,
                        principalTable: "ClientApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_ClientContactData_ClientContactDataId",
                        column: x => x.ClientContactDataId,
                        principalTable: "ClientContactData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_ClientFamilyDetailsData_ClientFamilyDetailsDataId",
                        column: x => x.ClientFamilyDetailsDataId,
                        principalTable: "ClientFamilyDetailsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientAddressDataId",
                table: "Clients",
                column: "ClientAddressDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientApplicationId",
                table: "Clients",
                column: "ClientApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientContactDataId",
                table: "Clients",
                column: "ClientContactDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientFamilyDetailsDataId",
                table: "Clients",
                column: "ClientFamilyDetailsDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientAddressData");

            migrationBuilder.DropTable(
                name: "ClientContactData");

            migrationBuilder.DropTable(
                name: "ClientFamilyDetailsData");
        }
    }
}
