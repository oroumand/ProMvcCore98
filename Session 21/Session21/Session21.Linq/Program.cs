using System;
using System.Collections.Generic;
using System.Linq;

namespace Session21.Linq
{
    public class JoinResult
    {
        public string FullName { get; set; }
        public string CarName { get; set; }
    }
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class Car
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = System.IO.File.ReadAllLines("d:\\people.txt");
            List<Car> cars = new List<Car>
            {
                new Car
                {
                    OwnerId = 1,
                    Name = "Ferrari"
                },
                    new Car
                {
                    OwnerId = 2,
                    Name = "Mustang"
                },
                new Car
                {
                    OwnerId = 3,
                    Name = "Bugatti"
                },
                new Car{
                    OwnerId = 3,
                    Name = "Prid"
                },
            };
            List<Person> list = new List<Person>();
            foreach (var item in data)
            {
                var attr = item.Split(',');
                Person person = new Person
                {
                    ID = int.Parse(attr[0]),
                    FirstName = attr[1],
                    LastName = attr[2],
                    Age = int.Parse(attr[3])
                };
                list.Add(person);

            }
            var linqResult = System.IO.File.ReadAllLines("d:\\people.txt").Select(str =>
            {
                var attr = str.Split(',');
                Person person = new Person
                {
                    ID = int.Parse(attr[0]),
                    FirstName = attr[1],
                    LastName = attr[2],
                    Age = int.Parse(attr[3])
                };
                return person;
            }).ToList();
            var orderedasc = linqResult.OrderBy(c => c.Age).ToList();
            var ordereddesc = linqResult.OrderByDescending(c => c.Age).ToList();
            var whereResult = linqResult.Where(c => c.Age > 100 && c.FirstName.Contains("H")).ToList();


            var top = linqResult.Take(2);
            var page2 = linqResult.Skip(2).Take(2);


            if (linqResult.Any(c => c.FirstName == "Hossin"))
            {

            }

            if (linqResult.All(c => c.FirstName == "Hossin"))
            {

            }

            var joinResult = linqResult.Join(cars, c => c.ID, car => car.OwnerId, (person, car) =>
            {
                return new JoinResult
                {
                    FullName = $"{person.FirstName}, {person.LastName}",
                    CarName = car.Name
                };
            }).ToList();

            var count = linqResult.GroupBy(c => c.FirstName).Count();
            var groupResult = linqResult.GroupBy(c => c.FirstName, (key, g) => new { PersonId = key, Cars = g.ToList() });
            foreach (var item in groupResult)
            {
              
            }

            Console.WriteLine("Hello World!");
        }
    }
}
