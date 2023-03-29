using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IApplyForJob
    {
        public ApplyForJob GetById(int id);
        public List<VwApplyJob> GetAll();
        public List<VwApplyJob> GetByJobId(int jobId);
        public List<VwApplyJob> GetByUserId(string userId);
        public bool Save(ApplyForJob applyJob);
        public bool Delete(int id);
    }

    public class ClsApplyForJob:IApplyForJob
    {
        JobOfferContext context;
        public ClsApplyForJob(JobOfferContext ctx)
        {
            context = ctx;
        }

        public ApplyForJob GetById(int id)
        {
            try
            {
                var item = context.TbApplyForJobs.FirstOrDefault(a => a.ApplyForJobId == id && a.CurrentState == 1);
                return item;
            }
            catch
            {
                return new ApplyForJob();
            }
        }

        public List<VwApplyJob> GetAll()
        {
            try
            {
                var lst = context.VwApplyJobs.Where(a => a.CurrentState == 1).ToList();
                return lst;
            }
            catch
            {
                return new List<VwApplyJob>();
            }

        }

        public List<VwApplyJob> GetByJobId(int jobId)
        {
            try
            {
                var lst = context.VwApplyJobs.Where(a => a.JobDetailId == jobId && a.CurrentState == 1).ToList();
                return lst;
            }
            catch
            {
                return new List<VwApplyJob>();
            }
        }


        public List<VwApplyJob> GetByUserId(string userId)
        {
            try
            {
                var lst = context.VwApplyJobs.Where(a => a.UserId == userId && a.CurrentState == 1).ToList();
                return lst;
            }
            catch
            {
                return new List<VwApplyJob>();
            }
        }

        public bool Save(ApplyForJob applyJob)
        {
            try
            {
                if (applyJob.ApplyForJobId == 0)
                {
                    applyJob.CurrentState = 1;
                    applyJob.ApplyDate = DateTime.Now;
                    context.TbApplyForJobs.Add(applyJob);
                }
                else
                {

                    context.Entry(applyJob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var item = GetById(id);

                item.CurrentState = 0;
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
