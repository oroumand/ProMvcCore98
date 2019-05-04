using Session08.EfDal;
using Session08.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session08.StateManagement
{
    public class HW01
    {

        public static void Update(Session08Context ctx, Person person, List<string> UpdateParameters)
        {
            UpdateParameters.ForEach(delegate (string param)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " ");
                Console.WriteLine("FirstName: " + ctx.Entry(person).Property(c => c.FirstName).IsModified);
                Console.WriteLine("LastName: " + ctx.Entry(person).Property(c => c.LastName).IsModified);
                Console.WriteLine("Person:" + ctx.Entry(person).State);

                ctx.Entry(person).Property(param).IsModified = true;

                Console.WriteLine("FirstName: " + ctx.Entry(person).Property(c => c.FirstName).IsModified);
                Console.WriteLine("LastName: " + ctx.Entry(person).Property(c => c.LastName).IsModified);
                Console.WriteLine("Person:" + ctx.Entry(person).State);

            });

            ctx.SaveChanges();
            Console.WriteLine("FirstName: " + ctx.Entry(person).Property(c => c.FirstName).IsModified);
            Console.WriteLine("LastName: " + ctx.Entry(person).Property(c => c.LastName).IsModified);
            Console.WriteLine("Person:" + ctx.Entry(person).State);
        }



    }
}
