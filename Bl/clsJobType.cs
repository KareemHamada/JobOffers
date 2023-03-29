using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IJobTypes
    {
        public List<JobType> GetAll();
        public JobType GetById(int id);
        public bool Save(JobType item);
        public bool Delete(int id);
    }
    public class clsJobType : IJobTypes
    {
        JobOfferContext context;
        public clsJobType(JobOfferContext ctx)
        {
            context = ctx;
        }


        public List<JobType> GetAll()
        {
            try
            {
                var lst = context.TbJobType.Where(a => a.CurrentState == 1).ToList();
                return lst;
            }
            catch
            {
                return new List<JobType>();
            }

        }

        public JobType GetById(int id)
        {
            try
            {
                var item = context.TbJobType.FirstOrDefault(a => a.JobTypeId == id && a.CurrentState == 1);
                return item;
            }
            catch
            {
                return new JobType();
            }
        }

        public bool Save(JobType item)
        {
            try
            {
                if (item.JobTypeId == 0)
                {
                    item.CurrentState = 1;
                    context.TbJobType.Add(item);
                }
                else
                {

                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
