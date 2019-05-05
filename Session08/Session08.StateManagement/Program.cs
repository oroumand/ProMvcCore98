using Session08.EfDal;
using System;

namespace Session08.StateManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new TeacherContext();
            //teacherContext.Database.EnsureCreated();


            //ctx.Teachers.DeleteAllAsync();

            Console.ReadLine();
        }
    }
}
