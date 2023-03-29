using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class applyForJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbApplyForJobs",
                columns: table => new
                {
                    ApplyForJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobDetailId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbApplyForJobs", x => x.ApplyForJobId);
                    table.ForeignKey(
                        name: "FK_TbApplyForJobs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbApplyForJobs_TbJobDetails_JobDetailId",
                        column: x => x.JobDetailId,
                        principalTable: "TbJobDetails",
                        principalColumn: "JobDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbApplyForJobs_JobDetailId",
                table: "TbApplyForJobs",
                column: "JobDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TbApplyForJobs_UserId",
                table: "TbApplyForJobs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbApplyForJobs");
        }
    }
}
