using Microsoft.EntityFrameworkCore;
using Session08.EfDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session08.StateManagement
{
    public class HW03
    {
        public static string GetTableName<Entity>(DbContext ctx) 
        {
            var entityType = ctx.Model.FindEntityType(typeof(Entity));
            var tableName = entityType.Relational().TableName;
            
         
            return tableName;
        }

        //foreach (var entityType in ctx.Model.GetEntityTypes())
        //{
        //    var tableName = entityType.Relational().TableName;
        //    Console.WriteLine(tableName);
        //    foreach (var propertyType in entityType.GetProperties())
        //    {
        //        var columnName = propertyType.Relational().ColumnName;
        //        Console.WriteLine(columnName);
        //    }
        //}
    }
}
