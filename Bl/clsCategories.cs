using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface ICategories
    {
        public List<Category> GetAll();
        public Category GetById(int id);
        public bool Save(Category category);
        public bool Delete(int id);
    }
    public class clsCategories : ICategories
    {
        JobOfferContext context;
        public clsCategories(JobOfferContext ctx)
        {
            context = ctx;
        }


        public List<Category> GetAll()
        {
            try
            {
                var lstcategories = context.TbCategories.Where(a => a.CurrentState == 1).ToList();
                return lstcategories;
            }
            catch
            {
                return new List<Category>();
            }

        }

        public Category GetById(int id)
        {
            try
            {
                var category = context.TbCategories.FirstOrDefault(a => a.CategoryId == id && a.CurrentState == 1);
                return category;
            }
            catch
            {
                return new Category();
            }
        }

        public bool Save(Category category)
        {
            try
            {
                if (category.CategoryId == 0)
                {
                    category.CurrentState = 1;
                    context.TbCategories.Add(category);
                }
                else
                {

                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var category = GetById(id);

                category.CurrentState = 0;
                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
