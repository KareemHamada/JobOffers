using Domains;

namespace JobOffers.Models
{
    public class VmJobListing
    {
        public VmJobListing()
        {
            lstAllJobs = new List<VwJob>();
            lstCategories = new List<Category>();
            lstJobLocations = new List<JobLocation>();
            lstJobTypes = new List<JobType>();
        }

        public List<VwJob> lstAllJobs { get; set; }
        public List<Category> lstCategories { get; set; }
        public List<JobLocation> lstJobLocations { get; set; }
        public List<JobType> lstJobTypes { get; set; }
        public int jobNums { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}
