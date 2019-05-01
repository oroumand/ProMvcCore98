using Microsoft.EntityFrameworkCore;
using Session08.EfDal;
using Session08.Entities;
using System;
using System.Linq;

namespace Session08.StateManagement
{
    public class Time01
    {
        private static void TrackGraph(Session08Context ctx)
        {
            var ctx2 = new Session08Context();
            var person = ctx.People.Include(c => c.JobData).Include(c => c.Contact).FirstOrDefault();
            ctx2.ChangeTracker.TrackGraph(person, c =>
            {
                switch (c.Entry.Entity)
                {
                    case Person p:
                        ctx2.Entry(p).State = EntityState.Unchanged;
                        Console.WriteLine("Person:" + p.PersonId);
                        break;
                    case JobData job:
                        ctx2.Entry(job).State = EntityState.Unchanged;
                        Console.WriteLine("Job:" + job.JobDataId);
                        break;
                    case Contact contact:
                        ctx2.Entry(contact).State = EntityState.Unchanged;
                        Console.WriteLine("contact:" + contact.ContactId);
                        break;
                }
            });
        }

        private static void UpdateIsModified(Session08Context ctx)
        {
            var ctx2 = new Session08Context();
            Person person = ctx2.People.FirstOrDefault();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine(ctx.Entry(person).Property(c => c.FirstName).IsModified);
            ctx.Entry(person).Property(c => c.FirstName).IsModified = true;
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine(ctx.Entry(person).Property(c => c.FirstName).IsModified);
            ctx.SaveChanges();
            Console.WriteLine(ctx.Entry(person).Property(c => c.FirstName).IsModified);
            Console.WriteLine("Person:" + ctx.Entry(person).State);
        }

        private static void Updata01(Session08Context ctx, Person person)
        {
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            person.FirstName = "Alire Reza";
            //ctx.People.Update(person);
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
        }

        private static void Delete02(Session08Context ctx, Person person)
        {
            JobData jobData = new JobData
            {
                JobTitle = "Programmr"
            };
            person.JobData = jobData;
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.People.Remove(person);
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
        }

        private static void Delete01(Session08Context ctx)
        {
            Person person = ctx.People.FirstOrDefault();
            JobData jobData = new JobData
            {
                JobTitle = "Programmr"
            };
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.People.Remove(person);
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
        }

        private static void Add03(Session08Context ctx, Person person)
        {
            JobData jobData = new JobData
            {
                JobTitle = "Programmr"
            };

            person.JobData = jobData;

            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);


            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);

            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
        }

        private static void Add02(Session08Context ctx)
        {
            Person person = new Person
            {
                FirstName = "Mahdi",
                LastName = "Hossini Nasab"
            };

            JobData jobData = ctx.JobDatas.FirstOrDefault();

            person.JobData = jobData;

            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.Add(person);

            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);

            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);

            Console.ReadLine();
        }

        private static void Add01(Session08Context ctx)
        {
            Person person = new Person
            {
                FirstName = "Alireza",
                LastName = "Oroumand"
            };

            JobData jobData = new JobData
            {
                JobTitle = "Programmr"
            };

            person.JobData = jobData;

            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.Add(person);

            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);

            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
        }
    }
}
