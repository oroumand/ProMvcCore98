using Microsoft.EntityFrameworkCore;
using Session08.Entities;
using System;

namespace Session08.EfDal
{
    public class Session08Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = .; initial catalog= session08;integrated security =true");           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>().HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot)
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<JobData> JobDatas{ get; set; }
    }


}
