using ASPNETCoreIdentitySample.Common.ReflectionToolkit;
using Microsoft.EntityFrameworkCore;
using Session08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Session08.EfDal
{
    public class HW02Context : DbContext
    {
        public DbSet<HW02> hW02s { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog= session8.HW02Db;Integrated security = true");
        }
        public override int SaveChanges()
        {
            ChangeCorrectYK();
            return base.SaveChanges();
        }

        private void ChangeCorrectYK()
        {
            var entities = ChangeTracker.Entries().Where(c => c.State == EntityState.Added || c.State == EntityState.Modified);
            foreach (var item in entities)
            {
                var propertyInfos = item.Entity.GetType().GetProperties
                    (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance
                    ).Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                var pr = new PropertyReflector();

                foreach (var propertyInfo in propertyInfos)
                {
                    var propName = propertyInfo.Name;
                    var val = pr.GetValue(item.Entity, propName);
                    if (val != null)
                    {
                        var newVal = val.ToString().Replace("ي", "ی").Replace("ک", "ک");
                        if (newVal == val.ToString()) continue;
                        pr.SetValue(item.Entity, propName, newVal);
                    }
                }

            }
        }
    }
}
