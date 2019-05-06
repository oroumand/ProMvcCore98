using Microsoft.EntityFrameworkCore;
using Session08.EfDal;
using Session08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Session08.StateManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HW-03

            var ctx = new Session08Context();

            string tblname = HW03.GetTableName<Contact>(ctx);
            ctx.Database.ExecuteSqlCommand((string)$"TRUNCATE TABLE {tblname}");

            #endregion

            #region HW-02
            //var HWctx = new HW02Context();
            //HWctx.hW02s.Add(new HW02
            //{
            //    FirstName="مهدي",
            //    LastName="کريمي",
            //    Description="اين آزمایش ي و ک است"
            //});

            //HWctx.SaveChanges();
            #endregion

            #region HW-01

            //var ctx = new Session08Context();
            //var person = ctx.People.Find(2);
            //List<string> UpdateParameters = new List<string>();
            //UpdateParameters.Add("LastName");
            //HW01.Update(ctx, person, UpdateParameters);

            #endregion

            Console.WriteLine("Perss any key");
            Console.ReadLine();
        }

        private static void ModelTest()
        {
            TeacherContext teacherContext = new TeacherContext();
            foreach (var item in teacherContext.Model.GetEntityTypes())
            {

            }
            Console.WriteLine("Perss any key");
        }

        private static void TransactionTest(TeacherContext teacherContext)
        {
            var teacher = teacherContext.KeyValues.FromSql("Select Id,Name from Strudent");
            //var cnn = teacherContext.Database.GetDbConnection().
            teacherContext.Database.ExecuteSqlCommand("");
            // var tran = teacherContext.Database.BeginTransaction();
        }

        private static void TestChangeTracker(TeacherContext teacherContext)
        {
            var person = teacherContext.Teachers.FirstOrDefault();
            //teacherContext.Teachers.Add(new
            //    Entities.Teacher
            //{
            //    FirstName = "Alireza",
            //    LastName = "Oroumand",                
            //});
            person.FirstName = "Ali reza";
            teacherContext.SaveChanges();

            person.LastName = "Oroumand AfterUpdate";
            teacherContext.SaveChanges();
            person.FirstName = "Alireza";
            teacherContext.SaveChanges();
        }

    }
}
