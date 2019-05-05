using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace Session08.StateManagement
{
    public static partial class Helper
    {
        public static void DeleteAllAsync<T>(this DbSet<T> dbSet) where T : class
        {
            DbContext dbContext = dbSet.GetDbContext();

            string tableName = dbSet.GetTableName();

            string deleteAllTableEntriesCommand = $"Delete From {tableName}";

            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.Database.ExecuteSqlCommandAsync(deleteAllTableEntriesCommand);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred." + Environment.NewLine + ex);
                }
            }
        }

        private static string GetTableName<T>(this DbSet<T> dbSet) where T : class
        {
            var entityTypes = dbSet.GetDbContext().Model.GetEntityTypes();
            var entityType = entityTypes.First(t => t.ClrType == typeof(T));
            var tableNameAnnotation = entityType.GetAnnotation("Relational:TableName");
            var tableName = tableNameAnnotation.Value.ToString();
            return tableName;
        }

        private static DbContext GetDbContext<T>(this DbSet<T> dbSet) where T : class
        {
            var infrastructure = dbSet as IInfrastructure<IServiceProvider>;
            var serviceProvider = infrastructure.Instance;
            var currentDbContext = serviceProvider.GetService(typeof(ICurrentDbContext))
                                       as ICurrentDbContext;
            var dbContext = currentDbContext.Context;
            return dbContext;
        }

        //public static void UpdatePartial<T>(this DbSet<T> dbSet ) where T : class
        //{
        //    DbContext ctx = dbSet.GetDbContext();
        //    dbSet.Update
        //    var entityTypes = dbSet.GetDbContext().Model.GetEntityTypes();
        //    var entityType = entityTypes.First(t => t.ClrType == typeof(T));

        //    T newEntity = new T();
        //    newTeacher.TeacherId = teacher.TeacherId;

        //    PropertyInfo[] properties = typeof(Teacher).GetProperties();

        //    foreach (var propertyName in teacher.UpdateListproperties.Keys)
        //    {
        //        var foundProp = findePropertyByName(propertyName);
        //        if (foundProp != null)
        //        {
        //            foundProp.SetValue(newTeacher, teacher.UpdateListproperties[propertyName]);
        //            ctx.Entry(newTeacher).Property(propertyName).IsModified = true;
        //        }

        //    }
        //    ctx.SaveChanges();

        //    PropertyInfo findePropertyByName(string propertyName)
        //    {
        //        for (int i = 0; i < properties.Length; i++)
        //        {
        //            if (properties[i].Name == propertyName)
        //                return properties[i];
        //        }
        //        return null;
        //    }
        //}

    }

}
