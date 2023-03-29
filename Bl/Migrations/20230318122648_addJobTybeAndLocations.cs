using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class addJobTybeAndLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobNature",
                table: "TbJobDetails");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TbJobDetails");

            migrationBuilder.AddColumn<int>(
                name: "JobLocationId",
                table: "TbJobDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "TbJobDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobLocations",
                columns: table => new
                {
                    JobLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocations", x => x.JobLocationId);
                });

            migrationBuilder.CreateTable(
                name: "TbJobType",
                columns: table => new
                {
                    JobTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbJobType", x => x.JobTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbJobDetails_JobLocationId",
                table: "TbJobDetails",
                column: "JobLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TbJobDetails_JobTypeId",
                table: "TbJobDetails",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbJobDetails_JobLocations_JobLocationId",
                table: "TbJobDetails",
                column: "JobLocationId",
                principalTable: "JobLocations",
                principalColumn: "JobLocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbJobDetails_TbJobType_JobTypeId",
                table: "TbJobDetails",
                column: "JobTypeId",
                principalTable: "TbJobType",
                principalColumn: "JobTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbJobDetails_JobLocations_JobLocationId",
                table: "TbJobDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TbJobDetails_TbJobType_JobTypeId",
                table: "TbJobDetails");

            migrationBuilder.DropTable(
                name: "JobLocations");

            migrationBuilder.DropTable(
                name: "TbJobType");

            migrationBuilder.DropIndex(
                name: "IX_TbJobDetails_JobLocationId",
                table: "TbJobDetails");

            migrationBuilder.DropIndex(
                name: "IX_TbJobDetails_JobTypeId",
                table: "TbJobDetails");

            migrationBuilder.DropColumn(
                name: "JobLocationId",
                table: "TbJobDetails");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "TbJobDetails");

            migrationBuilder.AddColumn<string>(
                name: "JobNature",
                table: "TbJobDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TbJobDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
