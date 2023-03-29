using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class ApplyForJob
    {
        [Key]
        public int ApplyForJobId { get; set; }
        [Required(ErrorMessage ="Please Enter message")]
        public string Message { get; set; }
        [ValidateNever]
        public DateTime ApplyDate { get; set; }
        [ValidateNever]
        public string PdfResume { get; set; }

        public int CurrentState { get; set; }

        public int JobDetailId { get; set; }
        [ValidateNever]
        public string UserId { get; set; }

        [ValidateNever]
        public virtual JobDetail JobDetail { get; set; }
        [ValidateNever]
        public virtual ApplicationUser user { get; set; }
    }
}
