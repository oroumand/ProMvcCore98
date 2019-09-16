using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session20.APIControllers.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    public interface PersonRepository
    {
        Person Get(int id);
        void Add(Person person);
        List<Person> GetAll();
    }
    public class FakePersonRepository : PersonRepository
    {
        private readonly List<Person> people = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "Alireza",
                LastName = "Oroumand"
            },
            new Person
            {
                Id = 2,
                FirstName="Mahdi",
                LastName = "Hossini nasab"
            }
        };
        public void Add(Person person)
        {
            person.Id = people.Count + 1;
            people.Add(person);
        }

        public Person Get(int id)
        {
            return people.FirstOrDefault(c => c.Id == id);
        }

        public List<Person> GetAll()
        {
            return people;
        }
    }
}
