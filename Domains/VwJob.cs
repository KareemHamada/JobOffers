using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class VwJob
    {
        public int JobDetailId { get; set; }

        public string JobName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDetails { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyWebsite { get; set; }
        public string EompanyEmail { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public string JobDescription { get; set; }
        public string RequiredKnowledge { get; set; }
        public string Education { get; set; }
        public DateTime PostedDate { get; set; }

        public int Vacancy { get; set; }

        public string ApplicationDate { get; set; }
        public int CurrentState { get; set; }
        public string userId { get; set; }
        public int categoryId { get; set; }
        public string CategoryName { get; set; }
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public int JobLocationId { get; set; }
        public string JobLocationName { get; set; }
    }
}
