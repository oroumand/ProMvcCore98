using Microsoft.EntityFrameworkCore;
using Session08.EfDal;
using Session08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session08.StateManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new TeacherContext();
           // ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

           // var teacher1 = ctx.Teachers.FirstOrDefault();
           // var dict = new Dictionary<string, string> { ["LastName"] = "moghadamNejad", ["Address"] ="tehran" };
          //  teacher1.UpdateListproperties = dict;
            // teacher1.UpdateListproperties=new
           // ctx.PartialListUpdate(teacher1);

            //ctx.RemoveAllStudent();
            Helper.RemoveAll(ctx.Students);

            Console.ReadLine();
        }

      


    }
}
