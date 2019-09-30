using Session22.Dapper.DAL;
using Session22.Dapper.Entities;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Session22.Dapper.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowPersonAndAddress();

            Console.WriteLine("Press any key...");
            Console.ReadLine();

        }

        private static void ShowPersonAndAddress()
        {
            var sqlConnection = new System.Data.SqlClient.SqlConnection("Server=.; initial catalog=Session22DB; integrated security=true");
            var personRepo = new PersonRipository(sqlConnection);
            var people = personRepo.GetPersonAndAddress();
            foreach (var item in people)
            {
                Console.WriteLine($"id: {item.PersonId} \t FirstName: {item.FirstName} \t LastName: {item.LastName} \t addressId: {item.Address.AddressId} addressLine: {item.Address.AddressLine}");
            }
        }

        private static void InsertAll()
        {
           var personForImport= System.IO.File.ReadAllLines("PersonForImport.txt").Select(c => {
                var lst = c.Split(',');
                var person = new Person
                {
                    FirstName = lst[0],
                    LastName = lst[1]
                };
                return person;
                }).ToList();

            var sqlConnection = new System.Data.SqlClient.SqlConnection("Server=.; initial catalog=Session22DB; integrated security=true");
            var personRepo = new PersonRipository(sqlConnection);
            personRepo.InsertAll(personForImport);
        }

        private static void Insert()
        {
            Console.WriteLine("FirstName: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("LastName: ");
            string lastName = Console.ReadLine();
            var sqlConnection = new System.Data.SqlClient.SqlConnection("Server=.; initial catalog=Session22DB; integrated security=true");
            var personRepo = new PersonRipository(sqlConnection);
            personRepo.Insert(firstName, lastName);
        }

        private static void Update()
        {
            Console.WriteLine("PersonId: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("FirstName: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("LastName: ");
            string lastName = Console.ReadLine();
            var sqlConnection = new System.Data.SqlClient.SqlConnection("Server=.; initial catalog=Session22DB; integrated security=true");
            var personRepo = new PersonRipository(sqlConnection);
            personRepo.Update(id, firstName, lastName);
        }

        private static void ShowList()
        {
            var sqlConnection = new System.Data.SqlClient.SqlConnection("Server=.; initial catalog=Session22DB; integrated security=true");
            var personRepo = new PersonRipository(sqlConnection);
            var people = personRepo.GetPeople();
            foreach (var item in people)
            {
                Console.WriteLine($"id: {item.PersonId} \t FirstName: {item.FirstName} \t LastName: {item.LastName}");
            }
        }

    }
}
