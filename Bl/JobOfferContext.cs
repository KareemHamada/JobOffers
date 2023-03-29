using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class JobOfferContext : IdentityDbContext<ApplicationUser>
    {
        public JobOfferContext(DbContextOptions<JobOfferContext> options)
        : base(options)
        {

        }

        public virtual DbSet<Category> TbCategories { get; set; }
        public virtual DbSet<JobDetail> TbJobDetails { get; set; }
        public virtual DbSet<VwJob> VwJobs { get; set; }

        public virtual DbSet<JobType> TbJobType { get; set; }
        public virtual DbSet<JobLocation> TbJobLocations { get; set; }
        public virtual DbSet<ApplyForJob> TbApplyForJobs { get; set; }
        public virtual DbSet<VwApplyJob> VwApplyJobs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{

            //}

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // for identity
            base.OnModelCreating(modelBuilder);
            //Seed(modelBuilder);

            modelBuilder.Entity<JobDetail>(entity =>
            {
                entity.HasOne(a => a.category).WithMany(a => a.jobDetails)
                .HasForeignKey(a => a.categoryId);

                entity.HasOne(a => a.jobType).WithMany(a => a.jobDetails)
                .HasForeignKey(a => a.JobTypeId);

                entity.HasOne(a => a.jobLocation).WithMany(a => a.jobDetails)
                .HasForeignKey(a => a.JobLocationId);

            });

            modelBuilder.Entity<VwJob>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwJobs");

            });

            modelBuilder.Entity<VwApplyJob>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwApplyJobs");

            });
        }

        //private void Seed(ModelBuilder modelBuilder)
        //{
        //    // Check if the Users table is empty

        //    if (!Users.Any())
        //    {
        //        // Add a default user

        //        Users.Add(new ApplicationUser { FirstName = "admin", LastName = "admin" ,Email="Admin@gmail.com",PasswordHash="123"});

        //        // Save changes to the database

        //        SaveChanges();
        //    }
        //}


    }
}
