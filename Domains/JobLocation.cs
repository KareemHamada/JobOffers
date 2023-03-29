using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class JobLocation
    {
        public JobLocation()
        {
            jobDetails = new HashSet<JobDetail>();
        }

        [Key]
        public int JobLocationId { get; set; }
        [Required]
        public string JobLocationName { get; set; }
        public int CurrentState { get; set; }

        public ICollection<JobDetail> jobDetails;
    }
}
