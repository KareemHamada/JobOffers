using Domains;

namespace JobOffers.Areas.admin.Models
{
    public class VmHomePage
    {
        public VmHomePage()
        {

        }
        public int lstCategoriesNum { get; set; }
        public int lstLocationsNum { get; set; }
        public int lstJobTypesNum { get; set; }
        public int lstJobsNum { get; set; }
        public int lstApplyedJobsNum { get; set; }
        public int lstUsersNum { get; set; }
    }
}
