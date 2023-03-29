using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Web.Mvc;

namespace Domains
{
    public class JobDetail
    {
        [Key]
        public int JobDetailId { get; set; }
        
        [Required(ErrorMessage = "Please Enter Job Name")]
        [MaxLength(20, ErrorMessage = "The Job Name field cannot exceed 20 characters.")]
        public string JobName { get; set; }
        [Required(ErrorMessage = "Please Enter Company Name")]
        [MaxLength(20, ErrorMessage = "The Company Name field cannot exceed 20 characters.")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please Enter Company Details")]
        public string CompanyDetails { get; set; }
        [Required(ErrorMessage = "Please Enter Company Address")]
        [MaxLength(20, ErrorMessage = "The Company Address field cannot exceed 20 characters.")]

        public string CompanyAddress { get; set; }
        [ValidateNever]
        public string CompanyLogo { get; set; }
        [Required(ErrorMessage = "Please Enter Company Website")]
        public string CompanyWebsite { get; set; }
        [Required(ErrorMessage = "Please Enter Eompany Email")]
        public string EompanyEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Minimum Salary")]
        public decimal MinSalary { get; set; }
        [Required(ErrorMessage = "Please Enter Maximum Salary")]
        public decimal MaxSalary { get; set; }
        [Required(ErrorMessage = "Please Enter Job Description")]
        [AllowHtml]
        public string JobDescription { get; set; }
        [Required(ErrorMessage = "Please Enter Required Knowledge")]
        [AllowHtml]
        public string RequiredKnowledge { get; set; }
        [Required(ErrorMessage = "Please Enter Education")]
        [AllowHtml]
        public string Education { get; set; }
        [Required(ErrorMessage = "Please Enter Posted Date")]
        public DateTime PostedDate { get; set; }

        [Required(ErrorMessage = "Please Enter Vacancy")]
        public int Vacancy { get; set; }

        [Required(ErrorMessage = "Please Enter Application Date")]
        public string ApplicationDate { get; set; }
        public int CurrentState { get; set; }
        [ValidateNever]
        public string userId { get; set; }


        [Required(ErrorMessage = "Please Enter Category")]
        public int categoryId { get; set; }

        [ValidateNever]
        public Category category { get; set; }


        [Required(ErrorMessage = "Please Enter job Type")]
        public int JobTypeId { get; set; }

        [ValidateNever]
        public JobType jobType { get; set; }

        [Required(ErrorMessage = "Please Enter Location")]
        public int JobLocationId { get; set; }

        [ValidateNever]
        public JobLocation jobLocation { get; set; }
    }
}
