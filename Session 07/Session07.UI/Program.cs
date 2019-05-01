using Microsoft.EntityFrameworkCore;
using MVCCore.Session07.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session07.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BlogSample();
         
            var ctx = new PersonContext();
            // ctx.Database.EnsureDeleted();
            // ctx.Database.EnsureCreated();
            //ctx.People.Add(new Person
            //{
            //    FirstName = "Mohammad",
            //    LastName = "Lotfi",
            //    Home = new Address
            //    {
            //        AddressLine = "Address",
            //        PhoneNumber = "234567890"
            //    },
            //    BankAccount = new BankAccount
            //    {
            //        AccNumber = "234567890"
            //    }
            //});
            //ctx.Teachers.Add(new Teacher
            //{
            //    FirstName = "Alireza",
            //    LastName = "Oroumand",
            //    Code = "123",
            //    Home = new Address
            //    {
            //        AddressLine = "Address",
            //        PhoneNumber = "234567890"
            //    },
            //    BankAccount = new BankAccount
            //    {
            //        AccNumber = "0987654"
            //    }
            //});
            //ctx.SaveChanges();

            //var persn = ctx.People.ToList();

           // var acc = ctx.BankAccounts.ToList();

            var personComp = ctx.People.Include(c => c.BankAccount).ToList();
            Console.WriteLine("Hello World!");
        }

        private static void BlogSample()
        {
            var ctx = new BlogContext();
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();

            //var blog = new Blog
            //{
            //    Name = "Nikamooz",
            //    CreateDate = DateTime.Now,
            //};
            //ctx.Blogs.Add(blog);
            //ctx.SaveChanges();

            //var posts = new List<Post> { new Post {BlogId = blog.Id,Body = "Post 01"},
            //new Post{BlogId = blog.Id,Body = "Post 01"},
            //new Post{BlogId = blog.Id,Body = "Post 01"}

            //};

            //ctx.Posts.AddRange(posts);
            //ctx.SaveChanges();

            //ctx.Blogs.Remove(blog);
            //ctx.SaveChanges();
            var posts = ctx.Posts.ToList();
            ctx.Blogs.Remove(new Blog
            {
                Id = 1
            });
            ctx.SaveChanges();
        }
    }
}
