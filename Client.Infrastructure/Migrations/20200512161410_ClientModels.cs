﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Infrastructure.Migrations
{
    public partial class ClientModels : Migration
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
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    OfficeId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsLoanOfficer = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
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
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PersonalId = table.Column<string>(maxLength: 20, nullable: false),
                    OfficeId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ActivationDateTime = table.Column<DateTime>(nullable: true),
                    ApprovalDateTime = table.Column<DateTime>(nullable: true),
                    SubmittedOnDate = table.Column<DateTime>(nullable: false),
                    ClientAddressDataId = table.Column<int>(nullable: true),
                    ClientFamilyDetailsDataId = table.Column<int>(nullable: true),
                    ClientContactDataId = table.Column<int>(nullable: true),
                    DocumentId = table.Column<Guid>(nullable: true),
                    StaffMemberId = table.Column<Guid>(nullable: true),
                    Status = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Clients_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_StaffMembers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RejectedClientApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    RejectionDate = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(maxLength: 100, nullable: false),
                    Note = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedClientApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RejectedClientApplications_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientAddressDataId",
                table: "Clients",
                column: "ClientAddressDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientContactDataId",
                table: "Clients",
                column: "ClientContactDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientFamilyDetailsDataId",
                table: "Clients",
                column: "ClientFamilyDetailsDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DocumentId",
                table: "Clients",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StaffMemberId",
                table: "Clients",
                column: "StaffMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedClientApplications_ClientId",
                table: "RejectedClientApplications",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejectedClientApplications");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientAddressData");

            migrationBuilder.DropTable(
                name: "ClientContactData");

            migrationBuilder.DropTable(
                name: "ClientFamilyDetailsData");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "StaffMembers");
        }
    }
}