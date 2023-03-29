using Domains;

namespace JobOffers.Models
{
    public class VmHomePage
    {
        public VmHomePage()
        {
            lstAllJobs = new List<VwJob>();
            lstJobLocations = new List<JobLocation>();
        }

        public List<VwJob> lstAllJobs { get; set; }
        public List<JobLocation> lstJobLocations { get; set; }

    }
}
