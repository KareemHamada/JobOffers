using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class views : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobName",
                table: "TbJobDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "TbJobDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyAddress",
                table: "TbJobDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");




            migrationBuilder.Sql(@"Create view VwJobs 
                as 
                SELECT dbo.TbJobDetails.JobDetailId, dbo.TbJobDetails.userId, dbo.TbJobDetails.JobName, dbo.TbJobDetails.CompanyName, dbo.TbJobDetails.CompanyLogo, dbo.TbJobDetails.MaxSalary, dbo.TbJobDetails.MinSalary, 
                  dbo.TbJobDetails.PostedDate, dbo.TbJobDetails.categoryId, dbo.TbCategories.CategoryName, dbo.TbJobDetails.CurrentState, dbo.TbJobType.JobTypeName, dbo.TbJobDetails.JobTypeId, dbo.TbJobLocations.JobLocationName, 
                  dbo.TbJobDetails.JobLocationId, dbo.TbJobDetails.CompanyDetails, dbo.TbJobDetails.CompanyAddress, dbo.TbJobDetails.CompanyWebsite, dbo.TbJobDetails.EompanyEmail, dbo.TbJobDetails.JobDescription, 
                  dbo.TbJobDetails.RequiredKnowledge, dbo.TbJobDetails.Education, dbo.TbJobDetails.Vacancy, dbo.TbJobDetails.ApplicationDate
FROM     dbo.TbCategories INNER JOIN
                  dbo.TbJobDetails ON dbo.TbCategories.CategoryId = dbo.TbJobDetails.categoryId INNER JOIN
                  dbo.TbJobLocations ON dbo.TbJobDetails.JobLocationId = dbo.TbJobLocations.JobLocationId INNER JOIN
                  dbo.TbJobType ON dbo.TbJobDetails.JobTypeId = dbo.TbJobType.JobTypeId
                ");


            migrationBuilder.Sql(@"Create view VwApplyJobs 
                as 
                SELECT dbo.TbApplyForJobs.ApplyForJobId, dbo.TbApplyForJobs.Message, dbo.TbApplyForJobs.ApplyDate, dbo.TbApplyForJobs.JobDetailId, dbo.TbApplyForJobs.UserId, dbo.TbApplyForJobs.PdfResume, dbo.AspNetUsers.FirstName, 
                  dbo.AspNetUsers.LastName, dbo.TbJobDetails.JobName, dbo.TbJobDetails.CompanyName, dbo.TbJobDetails.CompanyLogo, dbo.TbApplyForJobs.CurrentState
FROM     dbo.AspNetUsers INNER JOIN
                  dbo.TbApplyForJobs ON dbo.AspNetUsers.Id = dbo.TbApplyForJobs.UserId INNER JOIN
                  dbo.TbJobDetails ON dbo.TbApplyForJobs.JobDetailId = dbo.TbJobDetails.JobDetailId
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobName",
                table: "TbJobDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "TbJobDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyAddress",
                table: "TbJobDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
