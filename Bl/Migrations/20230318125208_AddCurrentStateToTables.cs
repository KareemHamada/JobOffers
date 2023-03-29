using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentStateToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbJobDetails_JobLocations_JobLocationId",
                table: "TbJobDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobLocations",
                table: "JobLocations");

            migrationBuilder.RenameTable(
                name: "JobLocations",
                newName: "TbJobLocations");

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbJobType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbJobLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbJobLocations",
                table: "TbJobLocations",
                column: "JobLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbJobDetails_TbJobLocations_JobLocationId",
                table: "TbJobDetails",
                column: "JobLocationId",
                principalTable: "TbJobLocations",
                principalColumn: "JobLocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbJobDetails_TbJobLocations_JobLocationId",
                table: "TbJobDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbJobLocations",
                table: "TbJobLocations");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbJobType");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbJobLocations");

            migrationBuilder.RenameTable(
                name: "TbJobLocations",
                newName: "JobLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobLocations",
                table: "JobLocations",
                column: "JobLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbJobDetails_JobLocations_JobLocationId",
                table: "TbJobDetails",
                column: "JobLocationId",
                principalTable: "JobLocations",
                principalColumn: "JobLocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
