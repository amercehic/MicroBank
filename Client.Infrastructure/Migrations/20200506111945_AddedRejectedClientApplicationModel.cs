using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Infrastructure.Migrations
{
    public partial class AddedRejectedClientApplicationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ClientApplicationId = table.Column<Guid>(nullable: false),
                    RejectionDate = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(maxLength: 100, nullable: false),
                    Note = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedClientApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RejectedClientApplications_ClientApplications_ClientApplicationId",
                        column: x => x.ClientApplicationId,
                        principalTable: "ClientApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RejectedClientApplications_ClientApplicationId",
                table: "RejectedClientApplications",
                column: "ClientApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejectedClientApplications");
        }
    }
}
