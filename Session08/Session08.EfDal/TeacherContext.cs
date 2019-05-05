using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Session08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            
            optionsBuilder.UseSqlServer(@"Data Source =.\MSSQLSERVER2017; Initial Catalog = Session08 - HomeWork; Integrated Security = True");
        }
      
        #region SaveChanes
        public override int SaveChanges()
        {
            ApplyPersianYeKeOnStringProperties();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyPersianYeKeOnStringProperties();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyPersianYeKeOnStringProperties();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyPersianYeKeOnStringProperties();
            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion

        private void ApplyPersianYeKeOnStringProperties()
        {
            var changedEntities = ChangeTracker.Entries()
                            .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added).Select(e => e.Entity);

            foreach (var entity in changedEntities)
            {
                if (entity == null)
                    continue;

                var properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var currentValue = (string)property.GetValue(entity, null);
                    if (!currentValue.HasValue())
                    {
                        continue;
                    }
                    var newValue = currentValue.ApplyPersianYeKe();
                    if (newValue == currentValue)
                        continue;
                    property.SetValue(entity, newValue, null);
                }
            }
        }

    }
}
