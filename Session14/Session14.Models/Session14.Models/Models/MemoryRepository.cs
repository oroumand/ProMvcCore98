using System;
using System.Collections.Generic;
using System.Linq;

namespace Session14.Models.Models
{
    public class MemoryRepository : IRepository
    {
        private List<Person> people = new List<Person>
        {
            new Person
            {
                PersonId = 1,
                FirstName = "Alireza",
                LastName = "Oroumand",
                IsApproved = true,
                BirthDate = new DateTime(1900,01,01),
                Role = Role.Admin,
                HomeAddress = new Address
                {
                    City = "Tehran",
                    Country = "Iran",
                    Line1 = "Home",
                    Line2 = "Work",
                    PostalCode = "1234567890"
                }
            },
            new Person
            {
                PersonId = 2,
                FirstName = "Nima",
                LastName = "Hosseini",
                IsApproved = true,
                BirthDate = new DateTime(1900,03,01),
                Role = Role.User,
                HomeAddress = new Address
                {
                    City = "Tehran",
                    Country = "Iran",
                    Line1 = "Home Nima",
                    Line2 = "Work Nima",
                    PostalCode = "1234567890"
                }
            },
                        new Person
            {
                PersonId = 3,
                FirstName = "Arash",
                LastName = "Ajdari",
                IsApproved = true,
                BirthDate = new DateTime(1902,11,11),
                HomeAddress = new Address
                {
                    City = "Tehran",
                    Country = "Iran",
                    Line1 = "Home Arash",
                    Line2 = "Work Arash",
                    PostalCode = "0987654324"
                }
            },
        };
       
        public IEnumerable<Person> People => people;


        public Person GetPerson(int id)
        {
            return people.FirstOrDefault(c => c.PersonId == id);
        }
    }
}

