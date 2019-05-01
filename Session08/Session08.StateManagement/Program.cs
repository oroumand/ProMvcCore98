using Microsoft.EntityFrameworkCore;
using Session08.EfDal;
using Session08.Entities;
using System;
using System.Linq;

namespace Session08.StateManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            TeacherContext teacherContext = new TeacherContext();
            foreach (var item in teacherContext.Model.GetEntityTypes())
            {
                
            } 
            Console.WriteLine("Perss any key");
            Console.ReadLine();
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
