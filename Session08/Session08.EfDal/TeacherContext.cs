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
        public DbSet<Student> Students { get; set; }
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

            optionsBuilder.UseSqlServer(@"Data Source=.\MSSQLSERVER2017;Initial Catalog=Practice1;Integrated Security=True");
        }

        public void PartialListUpdate(Teacher teacher)
        {
            var ctx = new TeacherContext();
            var newTeacher = new Teacher();
            newTeacher.TeacherId = teacher.TeacherId;

            PropertyInfo[] properties = typeof(Teacher).GetProperties();

            foreach (var propertyName in teacher.UpdateListproperties.Keys)
            {
                var foundedProp = findePropertyByName(propertyName);
                if (foundedProp != null)
                {
                    foundedProp.SetValue(newTeacher, teacher.UpdateListproperties[propertyName]);
                    ctx.Entry(newTeacher).Property(propertyName).IsModified = true;
                }

            }
            ctx.SaveChanges();

            PropertyInfo findePropertyByName(string propertyName)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].Name == propertyName)
                        return properties[i];
                }
                return null;
            }


        }
        public override int SaveChanges()
        {
            FixPersion();
            return base.SaveChanges();
        }


        private void FixPersion()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val!=null)
                    {
                        var newVal = val.FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }

        }
    }
}
