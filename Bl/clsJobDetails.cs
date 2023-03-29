using Bl;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IJobDetails { 
        public List<JobDetail> GetAll();
        public JobDetail GetById(int id);
        public bool Save(JobDetail category);
        public bool Delete(int id);
        public List<VwJob> GetAllViews();
        public List<VwJob> GetByCategoryId(int CategoryId);

        public List<VwJob> GetByUserId(string UserId);
        public VwJob GeViewtById(int id);

    }

    public class clsJobDetails : IJobDetails
    {
        JobOfferContext context;
        public clsJobDetails(JobOfferContext ctx)
        {
            context = ctx;
        }


        public List<JobDetail> GetAll()
        {
            try
            {
                var lstJobDetails = context.TbJobDetails.Where(a => a.CurrentState == 1).ToList();
                return lstJobDetails;
            }
            catch
            {
                return new List<JobDetail>();
            }

        }

        public List<VwJob> GetAllViews()
        {
            var lstJobDetails = context.VwJobs.Where(a => a.CurrentState == 1).OrderByDescending(a => a.PostedDate).ToList();
            return lstJobDetails;

            try
            {
                
            }
            catch
            {
                return new List<VwJob>();
            }

        }


        public JobDetail GetById(int id)
        {
            try
            {
                var jobDetail = context.TbJobDetails.FirstOrDefault(a => a.JobDetailId == id && a.CurrentState == 1);
                return jobDetail;
            }
            catch
            {
                return new JobDetail();
            }
        }

        public VwJob GeViewtById(int id)
        {
            try
            {
                var jobDetail = context.VwJobs.FirstOrDefault(a => a.JobDetailId == id && a.CurrentState == 1);
                return jobDetail;
            }
            catch
            {
                return new VwJob();
            }
        }


        public List<VwJob> GetByCategoryId(int CategoryId)
        {
            try
            {
                var jobDetails = context.VwJobs.Where(a => a.categoryId == CategoryId && a.CurrentState == 1).OrderByDescending(a => a.PostedDate).ToList();
                return jobDetails;
            }
            catch
            {
                return new List<VwJob>();
            }
        }

        public List<VwJob> GetByUserId(string UserId)
        {
            try
            {
                var jobDetails = context.VwJobs.Where(a => a.userId == UserId && a.CurrentState == 1).OrderByDescending(a => a.PostedDate).ToList();
                return jobDetails;
            }
            catch
            {
                return new List<VwJob>();
            }
        }

        public bool Save(JobDetail jobDetail)
        {
            try
            {
                if (jobDetail.JobDetailId == 0)
                {
                    jobDetail.CurrentState = 1;
                    jobDetail.PostedDate = DateTime.Now;
                    context.TbJobDetails.Add(jobDetail);
                }
                else
                {
                    context.Entry(jobDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var jobDetail = GetById(id);

                jobDetail.CurrentState = 0;
                context.Entry(jobDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //context.TbCategories.Remove(category);
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
