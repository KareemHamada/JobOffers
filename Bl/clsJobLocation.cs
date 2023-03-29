using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IJobLocations
    {
        public List<JobLocation> GetAll();
        public JobLocation GetById(int id);
        public bool Save(JobLocation item);
        public bool Delete(int id);
    }

    public class clsJobLocation : IJobLocations
    {
        JobOfferContext context;
        public clsJobLocation(JobOfferContext ctx)
        {
            context = ctx;
        }


        public List<JobLocation> GetAll()
        {
            try
            {
                var lst = context.TbJobLocations.Where(a => a.CurrentState == 1).ToList();
                return lst;
            }
            catch
            {
                return new List<JobLocation>();
            }

        }

        public JobLocation GetById(int id)
        {
            try
            {
                var item = context.TbJobLocations.FirstOrDefault(a => a.JobLocationId == id && a.CurrentState == 1);
                return item;
            }
            catch
            {
                return new JobLocation();
            }
        }

        public bool Save(JobLocation item)
        {
            try
            {
                if (item.JobLocationId == 0)
                {
                    item.CurrentState = 1;
                    context.TbJobLocations.Add(item);
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
