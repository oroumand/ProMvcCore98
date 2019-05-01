using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Session08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session08.EfDal
{
    public class TeacherContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbQuery<KeyValue> KeyValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var auditableEntities = modelBuilder.Model.GetEntityTypes().Where(c => typeof(IAuditable01).IsAssignableFrom(c.ClrType));
            foreach (var item in auditableEntities)
            {
                modelBuilder.Entity(item.ClrType).Property<int>("InsertBy");
                modelBuilder.Entity(item.ClrType).Property<int>("UpdateBy");
                modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate");
                modelBuilder.Entity(item.ClrType).Property<DateTime>("InsertDate");
            }
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server = .; initial catalog= session08.TeacherDb;integrated security =true");
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(c => typeof(IAuditable).IsAssignableFrom(c.Entity.GetType()));
            LogContext logContext = new LogContext();
            foreach (var item in entities)
            {
                var temp = item.Entity as IAuditable;
                var teacher = item.Entity as Teacher;
                if (item.State == EntityState.Added)
                {

                    temp.InsertBy = 1;
                    temp.InsertDate = DateTime.Now;
                    temp.UpdateBy = 1;
                    temp.UpdateDate = DateTime.Now;
                }
                if (item.State == EntityState.Modified)
                {
                    temp.UpdateBy = 1;
                    temp.UpdateDate = DateTime.Now;
                    
                    
                    var serializedDate = JsonConvert.SerializeObject(teacher);
                    logContext.DataChangeHistories.Add(new DataChangeHistory
                    {
                        EntityId = teacher.TeacherId.ToString(),
                        EntityType = teacher.GetType().FullName,
                        RegistrationDate = DateTime.Now,
                        SerializedData = serializedDate


                    });

                    
                }
            }
            logContext.SaveChanges();
            return base.SaveChanges();
        }
    }
}
