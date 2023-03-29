using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Category
    {

        public Category()
        {
            jobDetails = new HashSet<JobDetail>();
        }

        public int CategoryId { get; set; }
        [Required]
        //[Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Required]
        //[Display(Name="Category Type")]
        public string CategoryDescription { get; set; }

        public int CurrentState { get; set; }

        [ValidateNever]
        public string ImageName { get; set; }


        public ICollection<JobDetail> jobDetails { get; set; }

    }
}
