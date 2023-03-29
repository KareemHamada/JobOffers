using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class JobType
    {
        public JobType()
        {
            jobDetails = new HashSet<JobDetail>();
        }

        [Key]
        public int JobTypeId { get; set; }
        [Required]
        public string JobTypeName { get; set; }
        public int CurrentState { get; set; }

        public ICollection<JobDetail> jobDetails;
    }
}
