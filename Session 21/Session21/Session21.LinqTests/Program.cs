using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Session21.LinqTests.MyLinqTest;
namespace Session21.LinqTests
{
    public class Person
    {
        private string firstName;
        public string FirstName
        {
            get
            {
                throw new Exception();
                Console.WriteLine($"\t {firstName} {LastName}");
                return firstName;

            }
            set { firstName = value; }
        }
        public string LastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> developers = new List<Person>
            {
                new Person
                {
                    FirstName = "Hossin",
                    LastName = "Shamekh"
                },
                   new Person
                {
                    FirstName = "Hadi",
                    LastName = "Bahraman"
                },
            };

            //var myResult = developers.MyWhere(person => person.FirstName == "Hossin");


            //foreach (var item in myResult)
            //{
            //    Console.WriteLine($"FirtName: {item.FirstName} LastName: {item.LastName}");
            //}

            //foreach (var item in myResult)
            //{
            //    Console.WriteLine($"FirtName: {item.FirstName} LastName: {item.LastName}");
            //}

            //Console.WriteLine("".PadLeft(100, '*'));

            IEnumerable<Person> linqResult = null;
            try
            {
                linqResult = developers.Where(c => c.FirstName == "Hossin").ToList();
            }
            catch (Exception)
            {

            
            }
           
            foreach (var item in linqResult)
            {
                Console.WriteLine($"FirtName: {item.FirstName} LastName: {item.LastName}");
            }

            Console.WriteLine("".PadLeft(100, '*'));
            developers.Add(new Person
            {
                FirstName = "Hossin",
                LastName = "Khazaei"
            });
            foreach (var item in linqResult)
            {
                Console.WriteLine($"FirtName: {item.FirstName} LastName: {item.LastName}");
            }

            Console.Read();
        }
        //public static bool Condition(Person person)
        //{
        //    return person.FirstName == "Hossin";
        //}
        private static void ShowByLinq(string path)
        {
            var files = Directory.GetFiles(path);
            Console.WriteLine($"Count:{ files.Count()}");

        }
    }
}
