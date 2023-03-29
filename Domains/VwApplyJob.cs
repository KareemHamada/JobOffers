using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class VwApplyJob
    {
        public int ApplyForJobId { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }
        public string PdfResume { get; set; }
        public int CurrentState { get; set; }

        public int JobDetailId { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string JobName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
    }
}
