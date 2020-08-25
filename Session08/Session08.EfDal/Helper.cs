using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session08.EfDal
{
    public static class Helper
    {
        public static void RemoveAll<T>(this DbSet<T> dbSet) where T : class
        {
            var ctx = new TeacherContext();
            var tableName = ctx.Model.FindEntityType(typeof(T)).Relational().TableName;
            ctx.Database.ExecuteSqlCommand("Delete From " + tableName);
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");//.Replace("ئ", "ی");
        }
    }
}
